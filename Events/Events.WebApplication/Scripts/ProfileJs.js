$("body").on("click", "#sub", function ()
{
    var userId = $("#userId").text();
    var json = JSON.stringify({ "id":userId});
    $("#sub").attr("disabled", true);
    $.ajax({
        type: "POST",
        url: "http://localhost:15716/Users/Subscribe",
        data: json,
        contentType: "application/json",
        success: function (data) {                    
            $("#sub").val('Unsubscribe');
            $("#sub").attr('id', 'unsub');
            var subsCount = $("#subsCount").text();
            subsCount++;
            $("#subsCount").text(subsCount);
            $("#unsub").attr("disabled", false);
            debugger;

        },
        error:function(data){
            alert(data);
        },
            
        dataType: "json"
    });
});

$("body").on("click", "#unsub", function () {
    var userId = $("#userId").text();
    var json = JSON.stringify({ "id": userId });
    $("#unsub").attr("disabled", true);
    $.ajax({
        type: "POST",
        url: "http://localhost:15716/Users/Unsubscribe",
        data: json,
        contentType: "application/json",
        success: function (data) {                             
            $("#unsub").val('Subscribe');
            $("#unsub").attr('id', 'sub');
            var subsCount = $("#subsCount").text();
            subsCount--;
            $("#subsCount").text(subsCount);
            $("#sub").attr("disabled", false);
        },
        error: function (data) {
            alert(data);
        },
        dataType: "json"
       
    });
});