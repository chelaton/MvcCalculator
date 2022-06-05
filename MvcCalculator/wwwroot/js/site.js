// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function display(value) {
    document.getElementById("result").value += value;
}

function clearScreen() {
    document.getElementById("result").value = "";
}

function calculate() {
    var formula = document.getElementById("result").value;
    //var result = eval(formula);
    $.ajax({
        type: "POST",
        url: "/Home/Calculate",
        data: {
            data: document.getElementById("result").value
        },
        //contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                //alert("result : " + response);
                document.getElementById("result").value = response;
            } else {
                alert("Something went wrong");
            }
        },
        failure: function (response) {
            //alert("failure" + response.responseText);
            document.getElementById("result").value = response.responseText;
        },
        error: function (response) {
            //alert("Error" + response.responseText);
            document.getElementById("result").value = response.responseText;
        }
    });  
    document.getElementById("result").value = result;
}

function getCalcHistory() {

    $.ajax({
        type: "GET",
        url: "/Home/GetCalcHistory",
        dataType: "json",
        success: function (data) {
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                $("div.tableHistory").find('table tbody').append(`<tr> <td>${data[i]}</td> </tr>`);
            }
        },
        error: function (er) {
            console.log(er);
        }
    });
}

