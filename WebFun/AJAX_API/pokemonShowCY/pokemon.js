$(document).ready(function(){
    var htmlString = "";
    $("#first-gen").click(function(){
        for(var i = 1; i < 152; i++){
            htmlString += '<img src="http://pokeapi.co/media/img/'+[i]+'.png">'
        $("#catch").html(htmlString);
        }
    })
})