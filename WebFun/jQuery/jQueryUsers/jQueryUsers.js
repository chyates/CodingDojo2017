$(document).ready(function(){
    $("button").click(function(e){
        var firstName = $("#FN").val();
        var lastName =$("#LN").val();
        var emailAddress =$("#EA").val();
        var contactInfo =$("#CN").val();

        $("#t1 tr:last").after("<tr><td>" + firstName + "</td><td>" + lastName + "</td><td>" + emailAddress + "</td><td>" + contactInfo + "</td></tr>")
        $("form").trigger('reset');
    })
})