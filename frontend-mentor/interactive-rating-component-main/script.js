let options = document.querySelectorAll('.feedback__option');

for(let option of options){
    option.addEventListener('click', (e) => {
        var targetElement = e.target;
        let options = document.querySelectorAll('.feedback__option');
        
        for(let option of options ){
            option.classList.remove('feedback__option--selected')
        }

        targetElement.classList.add('feedback__option--selected')
    });
}

let submit = document.querySelector('.feedback__submit');

submit.addEventListener('click', (e) => {
    let option = document.querySelector('.feedback__option--selected');
    if(option == undefined)
        return;

    let feedbackRating = document.querySelector('.feedback__rating');
    feedbackRating.classList.add('feedback__rating--hidden');

    let feedbackAnswer = document.querySelector('.feedback__answer');
    feedbackAnswer.classList.remove('feedback__answer--hidden');

    let rating = document.querySelector('.feedback__choice');
    rating.innerHTML = option.innerHTML;
});