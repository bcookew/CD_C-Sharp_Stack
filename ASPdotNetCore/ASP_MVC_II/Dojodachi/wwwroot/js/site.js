// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getState() {
    var stats = {
        Happiness: $("#happy").text(),
        Meals: $("#meals").text(),
        Energy: $("#energy").text(),
        Fullness: $("#full").text()
    };
    return stats;
};

$(function(){
    
});

$("#sleep").on("click", function(){
    var stats = JSON.stringify(getState());
    console.log(stats);
    $.post("/sleep", stats, function(response){
        $("body").html(response)
    });
});