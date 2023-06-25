let button = document.querySelector('#mark-all-as-read');

button.addEventListener('click', (e) => {
    let unreadElements =  document.querySelectorAll('.notification-unread');

    for(let element of unreadElements)
        element.classList.remove('notification-unread');
});