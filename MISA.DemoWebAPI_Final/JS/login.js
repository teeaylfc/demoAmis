$(document).ready(function () {
    $('.fill').blur(function () { //Bôi đỏ viền input
        var vl = $(this).val();
        if (vl == '') {
            $(this).addClass('borderred');
        }
        else {
            $(this).removeClass('borderred');

        }
    });
    $('.fill2').blur(function () {
        var vl = $(this).val();
        if (vl == '') {
            $(this).addClass('borderred');
        }
        else {
            $(this).removeClass('borderred');

        }
    });
    $('.btnreg').click(loginJS.btnReg_OnClick);//Đăng kí tài khoản
    $('#btnLogin').click(loginJS.btnLogin_OnClick);//Đăng nhập
})

var loginJS = Object.create({
    btnLogin_OnClick: function () {
        $('.fill2').trigger('blur');
        // Lấy thông tin Username:
        var userName = $('#txtUserName').val().trim();
        // Lấy thông tin mật khẩu:
        var pw = $('#txtPassword').val().trim();
        // Gọi API kiểm tra thông tin:
        if (userName && pw) {
            $.ajax({
                method: "GET",
                dataType: "json",
                data: "json",
                contentType: "json",
                url: "/api/User?userName=" + userName + "&password=" + pw,
                success: function (response) {
                    if (response) {
                        location.href = "/Views/index.html";
                    } else {
                        alert('Sai tên người dùng hoặc mật khẩu!');
                    }
                },
                fail: function () {
                    alert('không thành công');
                }
            });
        } else {
            alert('Bạn chưa nhập tên người dùng');
        }

        
    },
    btnReg_OnClick: function () {
        $('.fill').trigger('blur');
        var usn = $('#userNameReg').val.trim;
        var pw = $('#passwordReg').val.trim;
        var user = {
            userName: usn,
            password: pw,
        };
        $.ajax({
            method:"POST",
            url:"api/User/",
            data: JSON.stringify(user), 
            dataType:'application/json',
            contentType:'application/json',
            success:function () {
                alert("Thêm thành công");
                location.href = "/Views/login.html"
            },
            fail:function () {
                alert("Thêm thất bại");
            },
        });
    }
})