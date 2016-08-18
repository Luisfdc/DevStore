var chatR = window.chatR = {
    hub: null,
    user: null,

    init: function () {
        chatR.load.signalR();
        chatR.load.events();
    },
    load: {
        events: function () {
            $("#message-text").keydown(chatR.actions.addMessage);
            $("#send-message").click(chatR.actions.addMessage);
        },
        signalR: function () {
            $.connection.hub.logging = true;
            chatR.hub = $.connection.chatHub;
            chatR.hub.client.newMessage = chatR.receive.newMessage;

            $.connection.hub.start().done(chatR.load.messages);
        },
        messages: function () {
            chatR.load.user();
            chatR.hub.server.getRecentMessages().done(function (resp) {
                for (var i = 0; i < resp.length; i++) {
                    resp[i].CreatedDate = (new Date(resp[i].CreatedDate)).toLocaleString();
                    $('#messages').append(chatR.addValueToTemplate(resp[i], $('#MessageTemplate').html()));


                    var wtf = $('#messages');
                    var height = wtf[0].scrollHeight;
                    wtf.scrollTop(height);
                }
            });
        },
        user: function () {
            var data = {
                User: {
                    Nome: ""
                }
            };
            var user = $.parseJSON(localStorage.getItem('user'));
            if (user != null) {
                data.User.Nome = user.Nome;

                var objMessege = chatR.addValueToTemplate(data, $("#NomeLogado").html());
                $('#logado').append(objMessege);

                chatR.user = user;
            } else {
                var name = prompt("Digite seu nome aqui.");
                chatR.hub.server.enterChat(name).done(function (resp) {

                    data.User.Nome = name;

                    var objMessege = chatR.addValueToTemplate(data, $("#NomeLogado").html());
                    $('#logado').append(objMessege);

                    chatR.user = resp.Object;
                    localStorage.setItem('user', JSON.stringify(resp.Object));
                });
            }
        }
    },
    receive: {
        newMessage: function (message, userName) {
            var data = {
                Texto: message.Texto,
                User: {
                    Nome: userName
                }
            };

            data.CreateDate = (new Date(message.CreateDate)).toLocaleString();

            var objMessege = chatR.addValueToTemplate(data, $("#MessageTemplate").html());

            $("#messages").append(objMessege);

            var wtf = $('#messages');
            var height = wtf[0].scrollHeight;
            $('#messages .row:last').hide().fadeIn(1000);

            wtf.animate({ scrollTop: height }, 300);
        }
    },
    actions: {
        addMessage: function (e) {
            if (e.keyCode === 13 || e.type !== 'keydown') {
                var message = $("#message-text").val();

                chatR.hub.server.sendMessage(message, chatR.user.Id, chatR.user.Nome).done(function () {
                    $("#message-text").val('').focus();
                });
            }
        }
    },
    addValueToTemplate: function (data, template) {
        if (typeof template === 'string') {
            for (var key in data) {
                if (typeof data[key] === "object" && data[key] != null && data[key] != undefined) {
                    for (var innerKey in data[key]) {
                        var innerPattern = new RegExp('{' + key + '.' + innerKey + '}', 'gi');
                        template = template.replace(innerPattern, data[key][innerKey]);
                    }
                } else {
                    if (data.hasOwnProperty(key)) {
                        var pattern = new RegExp('{' + key + ':.*?}|{' + key + '}', 'gi');
                        template = template.replace(pattern, data[key]);
                    }

                }
            }
            return template;
        } else {
            return "";
        }
    }
};

$(document).ready(chatR.init);