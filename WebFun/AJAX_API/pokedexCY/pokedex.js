$(document).ready(function () {
        for (var i = 1; i < 152; i++) {
        $("#catch").append('<img id=' + i + ' src="http://pokeapi.co/media/img/' + [i] + '.png">');
        }


    $("img").click(function () {
        var myID = $(this).attr("id");
        $.get("http://pokeapi.co/api/v1/pokemon/"+myID, function (res) {
            $("#deck-title").html(res.name);
            $("#pokeball").html("<img id="+myID+" src=http://pokeapi.co/media/img/"+myID+".png/>")
            $("#type").html("");
            for (var i=0; i<res.types.length; i++){
                $("#type").append("<li>"+res.types[i].name+"</li>")
            }
            $("#weight").html('<h4>Weight: </h4>'+res.weight);
            $("#height").html('<h4>Height: </h4>'+res.height);
        });
    })
})