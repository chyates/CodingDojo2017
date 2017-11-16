$(document).ready(function () {
    $("img").hover(function () {
        $(this).attr("src", $(this).attr("imgIDAlt"));
    }, function(){
        $(this).attr("src", "aunt_becky.jpg");
    })
})
