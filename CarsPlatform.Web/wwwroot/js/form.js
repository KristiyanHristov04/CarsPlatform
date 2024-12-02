const missingMakeCheckBox = document.getElementById('missing-make');
const selectMakeMenu2 = document.getElementById('select-make-menu');
const makeInput = document.getElementById('make-input');

const missingModelCheckBox = document.getElementById('missing-model');
const selectModelMenu2 = document.getElementById('select-model-menu');
const modelInput = document.getElementById('model-input');

const missingColourCheckBox = document.getElementById('missing-colour');
const selectColourMenu = document.getElementById('select-colour-menu');
const colourInput = document.getElementById('colour-input');

missingMakeCheckBox.addEventListener('change', (e) => {
    const isChecked = e.currentTarget.checked;
    console.log(isChecked);

    if (isChecked) {
        selectMakeMenu2.setAttribute('disabled', '');
        selectMakeMenu2.parentElement.classList.toggle('d-none');

        selectModelMenu2.setAttribute('disabled', '');
        selectModelMenu2.parentElement.classList.toggle('d-none');
        modelInput.parentElement.classList.toggle('d-none');
        missingModelCheckBox.parentElement.parentElement.classList.toggle('d-none');

        makeInput.parentElement.classList.toggle('d-none');
    } else {
        selectMakeMenu2.removeAttribute('disabled');
        selectMakeMenu2.parentElement.classList.toggle('d-none');

        selectModelMenu2.removeAttribute('disabled');
        selectModelMenu2.parentElement.classList.toggle('d-none');
        modelInput.parentElement.classList.toggle('d-none');
        missingModelCheckBox.parentElement.parentElement.classList.toggle('d-none');

        makeInput.parentElement.classList.toggle('d-none');
    }
});

missingModelCheckBox.addEventListener('change', (e) => {
    const isChecked = e.currentTarget.checked;
    console.log(isChecked);

    if (isChecked) {
        selectModelMenu2.setAttribute('disabled', '');
        selectModelMenu2.parentElement.classList.toggle('d-none');

        missingMakeCheckBox.parentElement.parentElement.classList.toggle('d-none');

        modelInput.parentElement.classList.toggle('d-none');
    } else {
        selectModelMenu2.removeAttribute('disabled');
        selectModelMenu2.parentElement.classList.toggle('d-none');

        missingMakeCheckBox.parentElement.parentElement.classList.toggle('d-none');

        modelInput.parentElement.classList.toggle('d-none');
    }
});

missingColourCheckBox.addEventListener('change', (e) => {
    const isChecked = e.currentTarget.checked;
    console.log(isChecked);

    if (isChecked) {
        selectColourMenu.setAttribute('disabled', '');
        selectColourMenu.parentElement.classList.toggle('d-none');
        colourInput.parentElement.classList.toggle('d-none');
    } else {
        selectColourMenu.removeAttribute('disabled');
        selectColourMenu.parentElement.classList.toggle('d-none');
        colourInput.parentElement.classList.toggle('d-none');
    }
});