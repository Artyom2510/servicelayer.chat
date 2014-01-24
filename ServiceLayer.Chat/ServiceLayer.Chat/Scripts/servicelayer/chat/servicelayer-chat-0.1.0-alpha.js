// var x is a Mock up user switch for use in testing with only one user
var x = 1;
var i = 327;
var lastSender = "new";


$("#chat-with-christian-header").on("click", function(e) {
    var target = $(e.target).attr('class');
    if (target === 'container pull-left' || target === 'navbar-header') {
        $("#chat-with-christian").toggleClass('chat-window-open chat-window-closed');
    }

});



function sendMessage(obj) {
    var data = [
    {
        "user": obj.SenderName,
        "chat": obj.Message 
}
    ];
    var html;
    if (data[0].user !== lastSender) {
        html = $("#chatItemStartTemplate").render(data);
        $("#chat-with-christian-items").append(html);
    } else {
        html = $("#chatItemTemplate").render(data);
        $("#chat-with-christian-items :last-child li").append(html);
    }

    lastSender = data[0].user;
    // switch to ID to allow for multiple chat windows.
    scrollDown(".chat-roll");
    
    
}


function scrollDown(element) {
    i = $(element)[0].scrollHeight;
    $(element).scrollTop(i);
    // Mock up user switch for use in testing with only one user
    x = x + 1;
}


var hub = $.connection.chatHub;

hub.client.sendMessage = sendMessage;
$.connection.hub.start().done(function() {
    $("#chattext").focus();

    $("#chattext").on("keyup", function(e) {
        e.preventDefault();
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code === 13) {
            var message = $(this).val();
            var username = $("#username").val();
            hub.server.sendChatMessage(message, username);
            $(this).val('').focus();

        }

    });

});

  
