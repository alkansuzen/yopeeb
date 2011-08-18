// JavaScript Document

$(function () {

    //Efeito dos campos de pesquisa Label, Input
    $("#top-bar input").focus(function () {
        $(this).parents("li").find("label").fadeOut(200)
    }).blur(function () {
        if ($(this).val() == "") {
            $(this).parents("li").find("label").fadeIn(200)
        }
    })

    $("#top-bar label").click(function () {
        $(this).fadeOut(200)
    })

    //Menu User
    $("#menu li.user a").click(function () {
        if ($(this).parents("li").find("ul").css("display") == "none") {
            $(this).parents("li").find("ul").slideDown(200)
        } else {
            $(this).parents("li").find("ul").slideUp(200)
        }
        return false
    })

    //Menu User
    $(".marcadores li.user a").click(function () {
        if ($(this).parents("li").find("ul").css("display") == "none") {
            $(this).parents("li").find("ul").slideDown(200)
        } else {
            $(this).parents("li").find("ul").slideUp(200)
        }
        return false
    })

    // abre a barra de pesquisa
    $("button.pesquisar").click(function () {
        $("#search-bar").slideDown(150)
        return false;
    })

    $("#search-bar .close").click(function () {
        $("#search-bar").slideUp(100)
        return false
    })

    // Ajuste de altura do iframe
    $("#iframeMapa").css({ "height": $(window).height() - 56, "margin-top": "48px" })

})