//Chart 1
    var vaccine = [];

    var title = ['Vaccine', 'Quantily'];
        vaccine.push(title);

        fetch('https://localhost:44387/api/GetVaccineDoses')
        .then(response => response.json())
        .then(data => {

            for(var i = 0; i < data.length; i++) {
                var temp = [];
                temp[0] = data[i].name;
                temp[1] = data[i].quantity;

                vaccine.push(temp);
            }

        })
console.log(vaccine);

//Done chart 1

//Start chart 2

    var Age = [];
    var head = ['Age', 'Quantity'];

    Age.push(head);

    fetch('https://localhost:44387/api/GetVaccineedByAge')
    .then(response => response.json())
    .then(data => {
        var older = 0;
        var teenager = 0;
        var mature = 0;
        for(var i = 0; i < data.length; i++) {
            if (data[i].year < 1957){
                older++;
            } 
            else if (data[i].year > 1991){
                teenager++;
            }
            else {
                mature++;
            }
        }
        
        var tner = ['18-30', teenager];
        Age.push(tner);

        var mture = ['31-65', mature];
        Age.push(mture);

        var oer = ['>65', older];
        Age.push(oer);

        //console.log(Age);

    })

var Month = [];
var header = ['Date', 'Vaccinated'];

Month.push(header);

fetch('https://localhost:44387/api/MonthStatus')
    .then(response => response.json())
    .then(data => {

        for (var i = 0; i < data.length; i++) {
            var temp = data[i].date;
            var s = temp.month + "/" + temp.year;

            var partial = [s, data[i].vaccineed];
            Month.push(partial);
        }
        //console.log(Month);

    })
    //piechart 1 vaccine
        // Load google charts
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart_vaccine);

        // Draw the chart and set the chart values
        function drawChart_vaccine() {
        var data_vaccine = google.visualization.arrayToDataTable(vaccine);

        // Optional; add a title and set the width and height of the chart
        var options_vaccine = {'title':'Rate of vaccine doses administered nationwide', is3D: true};

        // Display the chart inside the <div> element with id="piechart"
        var chart_vaccine = new google.visualization.PieChart(document.getElementById('piechart-vaccine'));
        chart_vaccine.draw(data_vaccine, options_vaccine);
        }
        // end of piechart 1

        //piechart 2 by age
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart_age);
        function drawChart_age() {
        var data_age = google.visualization.arrayToDataTable(Age);

        // Optional; add a title and set the width and height of the chart
        var options_age = {'title':'Vaccination rate by age', is3D: true};

        // Display the chart inside the <div> element with id="piechart"
        var chart_age = new google.visualization.PieChart(document.getElementById('piechart-age'));
        chart_age.draw(data_age, options_age);
        }
        // end of piechart 2

        // line chart
        google.charts.load('current',{packages:['corechart']});
        google.charts.setOnLoadCallback(drawChart_daily);

        function drawChart_daily() {
        // Set Data
        var data_daily = google.visualization.arrayToDataTable(Month);
        // Set Options
        var options_daily = {
        title: 'Month statistic',
        hAxis: {title: ''},
        vAxis: {title: 'vaccinated'},
        legend: 'none'
        };
        // Draw Chart
        var chart_daily = new google.visualization.LineChart(document.getElementById('myChart-daily'));
        chart_daily.draw(data_daily, options_daily);
        }
        // end of line chart

        // bar chart 1
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart_city_high);

        // Chart 3
        const titleHighest = ['City', 'vaccinated']
        var hightestVaccination = [];
        hightestVaccination.push(titleHighest)

        fetch('https://localhost:44387/api/GetHighestVaccination')
            .then(response => response.json())
            .then(data => {
                for (var i = 0; i < data.length; i++) {
                    var temp = [];
                    temp[0] = data[i].name;
                    temp[1] = data[i].vaccined;
                    hightestVaccination.push(temp)
                }
            })

        function drawChart_city_high() {
            var data_city_high = google.visualization.arrayToDataTable(hightestVaccination);


        var options_city_high = {
        title: 'Top 5 provinces with the highest vaccination'
        };

        var chart_city_high = new google.visualization.BarChart(document.getElementById('myChart-city-high'));
        chart_city_high.draw(data_city_high, options_city_high);
        }
        // end of bar chart 1
        

        // bar chart 2
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart_city_low);

        // Khúc này nữa nèeeeee
        const titleLowest = ['City', 'vaccinated']
        var lowestVaccination = [];
        lowestVaccination.push(titleLowest)

        fetch('https://localhost:44387/api/GetLowestVaccination')
            .then(response => response.json())
            .then(data => {
                for (var i = 0; i < data.length; i++) {
                    var temp = [];
                    temp[0] = data[i].name;
                    temp[1] = data[i].vaccined;
                    lowestVaccination.push(temp)
                }
            })

function drawChart_city_low() {
    var data_city_low = google.visualization.arrayToDataTable(lowestVaccination);
        // Tới đây hết rùiiiiiiiii


        var options_city_low = {
        title: 'Top 5 provinces with the lowest vaccination',
        };

        var chart_city_low = new google.visualization.BarChart(document.getElementById('myChart-city-low'));
        chart_city_low.draw(data_city_low, options_city_low);
        }
        // end of bar chart 2