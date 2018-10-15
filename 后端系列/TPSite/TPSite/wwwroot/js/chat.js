var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var tipsHide = "";
var targetAvatar = "";
connection.on("User", function (user, targetAvatar,message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " 说： " + msg + " " + getNowDate();
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    //var div = document.getElementById("messageBody");
    //div.scrollTop = div.scrollHeight;
    AddMsg(user, SendMsgDispose(message), null, targetAvatar);
    var div = document.getElementById("show");
    div.scrollTop = div.scrollHeight;
    _Notification(user, null);
});
connection.on("System", function (message) {
    if (message != null && message != "") {
        var msgs = document.getElementById("systemTips");
        msgs.innerText = message;
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
var vm = new Vue({
    el: "#app",
    data: {
        userName: "yepeng",
        textMsg: "",
        tipsHide: tipsHide,
        currentUserId: "",
        currentAvatar: "",
        targetAvatar: "",
        pageIndex: 1,
        pageSize: 20,
        historyMsg: [],
        isCanLoadhistoryMsg: true
    },
    created: function () {
        var self = this;
        document.onkeydown = function (e) {
            var key = window.event.keyCode;
            if (key == 13) {
                self.send();
                e.returnValue = false;//取消键盘默认事件
            }
        };
        //获取最近的聊天记录
        self.getHistoryMsg();
        setTimeout(function() {
            var div = document.getElementById("show");
            div.scrollTop = div.scrollHeight;
        },1000);
    },
    methods: {
        send() {
            var self = this;
            if (self.textMsg == "" || self.textMsg == null) {
                alert("请输入消息");
                return;
            }
            connection.invoke("SendUserMessage", self.textMsg).catch(function (err) {
                return console.error(err.toString());
            });
            AddMsg('default', SendMsgDispose(self.textMsg), self.currentAvatar, self.targetAvatar);
            self.textMsg = "";
            var div = document.getElementById("show");
            div.scrollTop = div.scrollHeight;
        },
        closeTips() {
            var self = this;
            self.tipsHide = "hide";
        },
        getHistoryMsg() {
            var self = this;
            $.get('/Chatroom/GetHistoryMessage',
                { pageIndex: self.pageIndex, pageSize: self.pageSize },
                function (res) {
                    if (res.statusCode == 200) {
                        if (res.data.result.length == self.pageSize) { //或许还有下一页
                            self.pageIndex++;
                        } else {
                            self.isCanLoadhistoryMsg = false;//没有下一页了
                        }
                        self.historyMsg = self.historyMsg.concat(res.data.result);
                        self.currentUserId = res.data.currentUserId;
                        self.currentAvatar = res.data.avatar.currentAvatar;
                        self.targetAvatar = res.data.avatar.targetAvatar;
                    } else {
                        alert(res.msg);
                        return;
                    }
                }, 'json');
        }
    }
});



// 发送信息
function SendMsg(currentAvatar, targetAvatar) {
    var text = document.getElementById("text");
    if (text.value == "" || text.value == null) {
        alert("发送信息为空，请输入！");
    }
    else {
        AddMsg('default', SendMsgDispose(text.value), currentAvatar, targetAvatar);
        text.value = "";
    }
    var div = document.getElementById("show");
    div.scrollTop = div.scrollHeight;
}
// 发送的信息处理
function SendMsgDispose(detail) {
    detail = detail.replace("\n", "<br>").replace(" ", "&nbsp;");
    return detail;
}

// 增加信息
function AddMsg(user, content, currentAvatar, targetAvatar) {
    var str = CreadMsg(user, content, currentAvatar, targetAvatar);
    var msgs = document.getElementById("msgs");
    msgs.innerHTML = msgs.innerHTML + str;
}

// 生成内容
function CreadMsg(user, content, currentAvatar, targetAvatar) {
    var avatarUrl = "https://www.v5kf.com/files/icons/201610/14761555537.png";
    if (currentAvatar == null || currentAvatar == '') {
        currentAvatar = avatarUrl;
    }
    if (targetAvatar == null || targetAvatar == '') {
        targetAvatar = avatarUrl;
    }
    var str = "";
    if (user == 'default') {
        str =
            "<div class=\"msg guest\"><div class=\"msg-right\"><div class=\"msg-host headDefault\"></div><div class=\"msg-ball\" title=\"今天 17:52:06\">" +
            content +
            "</div><div class=\"msg-host photo\" style=\"background-image: url('" + currentAvatar + "');\"></div></div></div>";
    }
    else {
        str = "<div class=\"msg robot\"><div class=\"msg-left\" worker=\"" + user + "\"><div class=\"msg-host photo\" style=\"background-image: url('" + targetAvatar + "')\"></div><div class=\"msg-ball\" title=\"今天 17:52:06\">" + targetAvatar + "</div></div></div>";
    }
    return str;
}

function _Notification(title, option) {
    var Notification = window.Notification || window.mozNotification || window.webkitNotification;
    Notification.permission === "granted" ? creatNotification(title, option) : requestPermission(title, option);
    function creatNotification(title, option) {
        var instance = new Notification(title, option);
        instance.onclick = function () {
            console.log('onclick');
        };
        instance.onerror = function () {
            console.log('onerror');
        };
        instance.onshow = function () {
            console.log('onshow');
        };
        instance.onclose = function () {
            console.log("close");
        };
    }
    function requestPermission(title, option) {
        Notification.requestPermission(function (status) {
            status === "granted" ? creatNotification(title, option) : failNotification(title);
        });
    }
    function failNotification(title) {
        var timer;
        return function (timer) {
            var index = 0;
            clearInterval(timer);
            timer = setInterval(function () {
                if (index % 2) {
                    document.head.getElementsByTagName("title")[0].innerHTML = '【　　　】' + title;
                } else {
                    document.head.getElementsByTagName("title")[0].innerHTML = '【新消息】' + title;
                }
                index++;
                if (index > 20) {
                    clearInterval(timer);
                }
            }, 500);
        }(timer);
    }
};
function getNowDate() {
    var date = new Date();
    var sign1 = "-";
    var sign2 = ":";
    var year = date.getFullYear(); // 年
    var month = date.getMonth() + 1; // 月
    var day = date.getDate(); // 日
    var hour = date.getHours(); // 时
    var minutes = date.getMinutes(); // 分
    var seconds = date.getSeconds(); //秒
    var weekArr = ['星期一', '星期二', '星期三', '星期四', '星期五', '星期六', '星期天'];
    var week = weekArr[date.getDay() - 1];
    // 给一位数数据前面加 “0”
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (day >= 0 && day <= 9) {
        day = "0" + day;
    }
    if (hour >= 0 && hour <= 9) {
        hour = "0" + hour;
    }
    if (minutes >= 0 && minutes <= 9) {
        minutes = "0" + minutes;
    }
    if (seconds >= 0 && seconds <= 9) {
        seconds = "0" + seconds;
    }
    var currentdate = year + sign1 + month + sign1 + day + " " + hour + sign2 + minutes + sign2 + seconds + " " + week;
    return currentdate;
}