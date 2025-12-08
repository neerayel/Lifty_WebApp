// Configuration variables - all values bound to these variables
const LINE_COUNT = 50;
const LINE_OPACITY = 0.5;
const ANIMATION_SPEED = 0.05;
const COLOR_HUE = 270; // Base hue for purple color (270 is purple)
const COLOR_SATURATION = 60; // Saturation percentage
const COLOR_LIGHTNESS = 30; // Lightness percentage
const LINE_WIDTH_MIN = 1; // Minimum line width in pixels
const LINE_WIDTH_MAX = 2; // Maximum line width in pixels
const AMPLITUDE_MIN = 20; // Minimum vertical movement range
const AMPLITUDE_MAX = 100; // Maximum vertical movement range
const SPEED_MIN = 0.5; // Minimum movement speed
const SPEED_MAX = 2.0; // Maximum movement speed

// DOM elements
const background = document.getElementById('background');

// Array to store line objects
let lines = [];

// Initialize the background
function initBackground() {
    // Clear existing lines
    background.innerHTML = '';
    lines = [];

    // Create lines
    for (let i = 0; i < LINE_COUNT; i++) {
        createLine(i);
    }

    // Start animation
    animateLines();
}

// Create a single line element
function createLine(index) {
    const line = document.createElement('div');
    line.classList.add('line');

    // Random initial position (0-100%)
    const top = Math.random() * 100;

    // Random width (80-100% of screen width)
    const width = 90 + Math.random() * 10;
    const leftOffset = Math.random() * 10;

    // Random line thickness
    const lineWidth = LINE_WIDTH_MIN + Math.random() * (LINE_WIDTH_MAX - LINE_WIDTH_MIN);

    // Random amplitude for vertical movement
    const amplitude = AMPLITUDE_MIN + Math.random() * (AMPLITUDE_MAX - AMPLITUDE_MIN);

    // Random movement speed
    const speed = SPEED_MIN + Math.random() * (SPEED_MAX - SPEED_MIN);

    // Random starting phase in the wave
    const phase = Math.random() * Math.PI * 2;

    // Calculate color with slight variations
    const hueVariation = Math.random() * 30 - 15; // ±15 degrees
    const hue = COLOR_HUE + hueVariation;
    const saturation = COLOR_SATURATION + Math.random() * 20 - 10; // ±10%
    const lightness = COLOR_LIGHTNESS + Math.random() * 10 - 5; // ±5%

    // Set line styles
    line.style.top = `${top}%`;
    line.style.left = leftOffset + '%';
    line.style.width = `${width}%`;
    line.style.height = `${lineWidth}px`;
    line.style.opacity = LINE_OPACITY;
    line.style.backgroundColor = `hsl(${hue}, ${saturation}%, ${lightness}%)`;
    line.style.boxShadow = `0 0 ${6 + Math.random() * 6}px rgba(90, 42, 138, ${0.5 + Math.random() * 0.3})`;

    // Store line data for animation
    lines.push({
        element: line,
        top: top,
        amplitude: amplitude,
        speed: speed,
        phase: phase
    });

    background.appendChild(line);
}

// Animate lines using JavaScript
function animateLines() {
    let lastTime = 0;

    function updateLines(timestamp) {
        if (!lastTime) lastTime = timestamp;
        const deltaTime = (timestamp - lastTime) / 1000; // Convert to seconds
        lastTime = timestamp;

        // Update each line position
        lines.forEach(line => {
            // Update phase based on time and speed
            line.phase += deltaTime * line.speed * ANIMATION_SPEED;

            // Calculate new position using sine wave for smooth motion
            const newTop = line.top + Math.sin(line.phase) * line.amplitude;

            // Apply new position
            line.element.style.top = `${newTop}%`;
        });

        // Continue animation
        requestAnimationFrame(updateLines);
    }

    // Start animation loop
    requestAnimationFrame(updateLines);
}

// Initialize on load
window.addEventListener('load', initBackground);

// Handle window resize
window.addEventListener('resize', function () {
    // Recalculate line positions on resize
    lines.forEach(line => {
        // Keep the line's relative position
        const currentTop = parseFloat(line.element.style.top);
        line.top = currentTop % 100;
    });
});

