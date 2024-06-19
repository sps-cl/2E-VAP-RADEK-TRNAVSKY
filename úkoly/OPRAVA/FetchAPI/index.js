// tento kód mi načítá data z webové stránky
document.addEventListener('DOMContentLoaded', function () {
    fetch('https://api.thingspeak.com/channels/2414963/feeds.json?results=8000')
        .then(response => response.json())
        .then(data => {
            const feeds = data.feeds;
            const tableBody = document.querySelector('#data-table tbody');

            // tento kód zobrazí posledních 10 hodnot teploty a tlaku v tabulce
            const last10Feeds = feeds.slice(-10).reverse();
            last10Feeds.forEach(feed => {
                const row = document.createElement('tr');
                const tempCell = document.createElement('td');
                const pressureCell = document.createElement('td');

                tempCell.textContent = feed.field1 ? feed.field1 : 'N/A';
                pressureCell.textContent = feed.field2 ? feed.field2 : 'N/A';

                row.appendChild(tempCell);
                row.appendChild(pressureCell);

                tableBody.appendChild(row);
            });

            // tento kód počítá průměrné hodnoty teploty a tlaku
            let totalTemp = 0;
            let totalPressure = 0;
            let tempCount = 0;
            let pressureCount = 0;

            feeds.forEach(feed => {
                const temp = parseFloat(feed.field1);
                const pressure = parseFloat(feed.field2);

                if (!isNaN(temp)) {
                    totalTemp += temp;
                    tempCount++;
                }

                if (!isNaN(pressure)) {
                    totalPressure += pressure;
                    pressureCount++;
                }
            });

            const avgTemp = totalTemp / tempCount;
            const avgPressure = totalPressure / pressureCount;

            document.getElementById('average-temperature').textContent = `Průměrná teplota: ${avgTemp.toFixed(2)} °C`;
            document.getElementById('average-pressure').textContent = `Průměrný tlak: ${avgPressure.toFixed(2)} hPa`;
        })
    });