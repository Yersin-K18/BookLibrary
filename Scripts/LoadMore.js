const loadMoreSpan = document.querySelector('.load-more span');
const hiddenItems = document.querySelectorAll('.tg-widgetcontent li:nth-child(n+11)');

// Hide all items after the sixth one
for (let i = 0; i < hiddenItems.length; i++) {
    hiddenItems[i].style.display = 'none';
}

// Show more items when the button is clicked
loadMoreSpan.addEventListener('click', function () {
    for (let i = 0; i < hiddenItems.length; i++) {
        hiddenItems[i].style.display = 'list-item';
    }
    loadMoreSpan.style.display = 'none';
});