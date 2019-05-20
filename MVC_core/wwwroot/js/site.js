// Write your JavaScript code.


$(document).ready(function () {
    $(document).off('click.bs.dropdown.data-api');
});//恢复菜单点击

$(document).ready(function () {
    dropdownOpen();//调用
});
function dropdownOpen(){
    $(".dropdown").mouseover(function () {
        $(this).addClass("open");
    });

    $(".dropdown").mouseleave(function () {
        $(this).removeClass("open");
    });

}//下拉菜单自动展开
$(function () {
    $('.shutter').shutter({
        shutterW: $("#GetActualSize").width,
        shutterH: $("#GetActualSize").outerHeight(true),
        isAutoPlay: true, // 是否自动播放
        playInterval: 4000, // 自动播放时间
        curDisplay: 3, // 当前显示页
        fullPage: false // 是否全屏展示
    });
});



/*



$(document).ready(
    $("#get").click(function () {

        $.get("/api/Form/5", function (data) {
            $("#content").val("you recived " + data);
        });
    })
);
$(document).ready(function () {
    $("#Login_in").click(function () {
        //$("#request-process-patent").html("正在提交中");

        $.ajax(
            {
                type: "Post",
                url: "/api/Api",
                contentType: 'application/json',
                data: JSON.stringify(GetJsonData()),
                //dataType: "json",
                success: function (data) {
                    // $("#request-process-patent").html("提交成功");
                    if (data === 0) {
                        alert("User logged successfully!");
                        $("#tempButton").click();
                    }
                    else if (data === 1) {
                        alert("Administrator logged successfully!");
                        $("#tempButton").click();
                    }
                    else {
                        alert("Login failed,try again?");
                    }
                },
                error: function () {
                    alert("error");
                }

            });
    });
});
$(document).ready(function () {
    $("#Register").click(function () {
        //$("#request-process-patent").html("正在提交中");
        $.ajax(
            {
                type: "Post",
                url: "/api/Api/5",
                contentType: 'application/json',
                data: JSON.stringify(GetRegisterJsonData()),
                //dataType: "json",
                success: function (data) {
                    // $("#request-process-patent").html("提交成功");
                    if (data) {
                        alert("注册成功");
                    }
                    else {
                        alert("注册失败");
                    }
                },
                error: function () {
                    alert("数据提交失败");
                }

            });
    });

});
   

function GetJsonData() {
    var json = {
        name: $("#Login_name").val(),
        password: $("#Login_password").val()
    };
    return json;
}


function GetRegisterJsonData() {
    var json = {
        name: $("#Register_name").val(),
        password: $("#Register_password").val()
    };
    return json;
}

*/