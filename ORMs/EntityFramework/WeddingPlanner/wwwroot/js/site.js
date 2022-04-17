// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).foundation()

$(function(){
    $("#login").on("click", function(){
        $.get("LoginForm",function (response) {
            $("#modalBody").html(response)
            $("#modal").foundation("open")
        })
    });
    $("#register").on("click", function(){
        $.get("RegistrationForm",function (response) {
            $("#modalBody").html(response)
            $("#modal").foundation("open")
        })
    });
    $("#newWedding").on("click", function(){
        $.get("RegistrationForm",function (response) {
            $("#modalBody").html(response)
            $("#modal").foundation("open")
        })
    });
});


    
