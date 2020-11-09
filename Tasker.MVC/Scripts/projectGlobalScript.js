$(document).ready(function () {
    if (document.getElementById('ddl') != null)
        onChangeFunc(document.getElementById('ddl').value);
});


function onChangeFunc(value) {

    var elTxt = document.getElementById('txt');
    var elNum = document.getElementById('num');
    var elDat = document.getElementById('dat');
    var elBol = document.getElementById('bol');
    var elTim = document.getElementById('tim');

    if (value == 'Name' || value == 'Description') {
        elTxt.style.display = "inline-block";
    } else if (elTxt != null) {
        elTxt.style.display = "none";
        elTxt.value = '';
    }
    if (value == 'Priority') {
        elNum.style.display = "inline-block";
    } else if (elNum != null) {
        elNum.style.display = "none";
        elNum.value = '';
    }
    if (value == 'DueDate') {
        elDat.style.display = "inline-block";
    } else if (elDat != null) {
        elDat.style.display = "none";
        elDat.value = '';
    }
    if (value == 'Completed') {
        elBol.style.display = "inline-block";
    } else if (elBol != null) {
        elBol.style.display = "none";
        elBol.value = '';
    }
    if (value == 'EstimatedTime' || value == 'TimeSpent') {
        elTim.style.display = "inline-block";
    } else if (elTim != null) {
        elTim.style.display = "none";
        elTim.value = '';
    }
}