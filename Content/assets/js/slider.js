var slides = document.querySelectorAll('.slideb');
var currentSlide = 0;
var slideInterval = setInterval(nextSlide, 3000); // Chuyển slide sau mỗi 5 giây

function nextSlide() {
    slides[currentSlide].classList.remove('active');
    currentSlide = (currentSlide + 1) % slides.length;
    slides[currentSlide].classList.add('active');
}