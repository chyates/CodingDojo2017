$(document).ready(function () {
    $("img").click(function () {
        $(this).attr("src", $(this).attr("data-alt-src"))
    })

    $("#b-FH").click(function () {
        $("#DT0").attr("src", "dannytanner0.jpg");
        $("#DT1").attr("src", "dannytanner1.jpg");
        $("#DT2").attr("src", "dannytanner2.jpg");
        $("#DT3").attr("src", "dannytanner3.jpg");
        $("#DT4").attr("src", "dannytanner4.jpg");
    })
})
