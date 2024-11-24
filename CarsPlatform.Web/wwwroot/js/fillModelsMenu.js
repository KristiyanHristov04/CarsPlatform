const selectMakeMenu = document.getElementById('select-make-menu');
const selectModelMenu = document.getElementById('select-model-menu');
const previousModelSelected = selectModelMenu.getAttribute('data-previous-model');
console.log('Previous model: ' + previousModelSelected);

enableModelMenuIfMakeIsSelected(selectMakeMenu.value);

selectMakeMenu.addEventListener('change', (e) => {
    enableModelMenuIfMakeIsSelected(selectMakeMenu.value);
});

function enableModelMenuIfMakeIsSelected(currentMakeValue) {
    if (currentMakeValue.length !== 0) {
        selectModelMenu.innerHTML = '';
        selectModelMenu.removeAttribute('disabled');
        const option = document.createElement('option');
        option.value = '';
        option.text = "None";
        selectModelMenu.appendChild(option);
        getValidModels(currentMakeValue);
    } else if (currentMakeValue.length === 0) {
        selectModelMenu.innerHTML = '';
        selectModelMenu.setAttribute('disabled', '');
    }
}

function getValidModels(currentMakeValue) {
    fetch(`https://localhost:7076/api/Cars?make=${currentMakeValue}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
            data.forEach(model => {
                console.log(model)
                const option = document.createElement('option');
                option.value = model;
                option.text = model;
                if (model === previousModelSelected) {
                    option.selected = true;
                }
                selectModelMenu.appendChild(option);
            })
        })
        .catch(err => console.error(err));
}