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

    // Beep Action
    $("a.share-beep").click(function () {
        $("form").submit();
    });

    $("#datepicker").datepicker({
        showOn: "button",
        buttonImage: "http://beepoy.com/Content/Images/icons/calendar.png",
        buttonImageOnly: true,
        onSelect: function (date, obj) {
            $("#datepicker").datepicker("option", "buttonImage", "http://beepoy.com/Content/Images/icons/calendar_on.png");
        }
    });

    $(".share-where, .share-when, #box-what, .item-link").tipsy({
        gravity: 'sw'
    });

    /*
    $(".share-where, .item-link-place").hover(
    function () {
    $(this).css("background-position", "left top");
    },
    function () {
    $(this).css("background-position", "left bottom");
    }
    );

    $(".share-when img").hover(
    function () {
    $(this).attr("src", "http://beepoy.com/Content/Images/icons/calendar.png");
    },
    function () {
    $(this).attr("src", "http://beepoy.com/Content/Images/icons/calendar.png");
    }
    );
    */

    $(".share-beep").hover(
        function () {
            $(this).css("background-position", "left center");
        },
        function () {
            $(this).css("background-position", "left top");
        }
    );

})