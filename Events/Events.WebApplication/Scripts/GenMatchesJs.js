

$("body").on("click", "#GenMatches", function () {
   
    $.ajax({
        type: "GET",
        url: "http://localhost:26557/api/GenerateFixture/GetMatches",
        contentType: "application/json",
        success: function (data) {
            var fixture = data;
            info = ko.toJS(fixture);
            
            debugger;
             var ViewModel = {
                 games: ko.observableArray()
             };
            
             ViewModel.games = data;
             $("#matches")
            .append('<table><thead><tr><th>Round</th><th>Game</th></tr></thead><tbody data-bind="foreach: games"><tr><td data-bind="text: Round"></td><td data-bind="text: Game"></td></tr></tbody></table>');
                 //.append('<ul data-bind="template: { foreach: games }"><li><span data-bind="text: Round"></span><span data-bind="template: { foreach: Game }"></span></li></ul>');
                
             ko.applyBindings(ViewModel);
        },
        error: function (data) {

        },

        dataType: "json"
    });
});




