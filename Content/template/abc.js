document.addEventListener("DOMContentLoaded", function () {
    createStars();
});

function createStars() {
    for (let i = 0; i < 100; i++) {
        setTimeout(() => {
            const star = document.createElement("div");
            star.classList.add("star");
            star.style.right = Math.random() * window.innerWidth + "px";
            document.body.appendChild(star);
        }, Math.random() * 5000);
    }
}