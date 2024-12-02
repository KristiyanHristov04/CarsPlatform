const canvas = document.getElementById('canvas');

fetch('https://localhost:7076/api/cars/getmakes')
    .then(response => response.json())
    .then(data => {
        const arrayData = Object.entries(data);
        console.log(arrayData);
        new Chart(canvas, {
            type: 'pie',
            data: {
                labels: arrayData.map(x => x[0]),
                datasets: [{
                    label: ' Total',
                    data: arrayData.map(x => x[1]),
                    borderWidth: 1,
                    hoverBorderColor: 'black',
                    offset: 0,
                    hoverOffset: 20
                }]
            },
            options: {
                plugins: {
                    title: {
                        display: true,
                        text: "Top 6 Makes",
                        font: {
                            size: 30
                        }
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });
    })
    .catch(err => console.error(err));