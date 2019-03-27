$(document).ready(function () {
    postJs.loadData();
  //  commmentJs.loadData();
    $('#iconLike').click(postJs.iconLike_Click);
    $('#btnSendStatus').click(postJs.upPost_Click);// Up status
})

var postJs = Object.create({
    loadData: function () { // load dữ liệu post
        $.ajax({
            method: "GET",
            url: "/api/Post",
            success: function (data) {
                if (data && data.length > 0) {
                    $('#allPosts').html('');
                    data.forEach(function (item, index) {
                        var htmlItem = '<div id="newsFeed" UserID = "' + item.UserID + '">' +
                            ' <img id="avatarStatus"  src="..' + item.Avatar + '" />' +
                            '<a href="#"><h6>' + item.FullName + '</h6></a>' +
                            '<p id="CreatedDate">' + item.CreatedDate + '</p>' +
                            '<div id="contentStatus">' +
                            '<textarea id="txtContent" readonly="true">' + item.PostContent +

                            '</textarea>' +
                            '</div>' +
                            '<div id="likeCount">' +
                            '<ul>' +
                            '<li id="iconLike"><span class="glyphicon glyphicon-thumbs-up"></span>Thích</li>' +
                            '<li style="margin-right:5px;">' + item.LikeCount + ' Thích</li>' +
                            '<li>Bình luận</li>' +
                            '</ul>' +

                            '</div>' +
                            '<div id="allComment">' +
                            '<div id="comment">' +
                            '<div id="commentBy">' +
                            '<img id="avatarStatus" src="../IMG/EmployeeImage.png" />' +
                            '<a href="#"><h6>Lê Tuấn Anh</h6></a>' +
                            '<p>Sao thế b</p>' +
                            '</div>' +
                            '</div>' +
                            '<div id="comment">' +
                            '<div id="commentBy">' +
                            '<img id="avatarStatus" src="../IMG/LTA.jpg" />' +
                            '<a href="#"><h6>Lê Tuấn Anh</h6></a>' +
                            '<p>Gì đây</p>' +
                            '</div>' +
                            '</div>' +
                            '</div>' +
                            '<div id="writeComment">' +
                            '<input id="txtWriteComment" type="text" name="name" value="" placeholder="Viết bình luận...." />' +
                            '<input type="button" class="btn btn-primary" name="name" value="Gửi" />' +
                            '<div id="marginStatus"></div>' +
                            '</div>' +
                            '</div>';

                        $('#allPosts').append(htmlItem);
                    })
                }
            },
            fail: function () {

            }
        })
    },
    iconLike_Click: function () { 
        $(this).addClass('likeAction');
    },
    upPost_Click : function () {  // Đăng status
        var UID = "7DA2349F-D0A8-4878-89F7-336DC00BC8AF";
        var PC = $('#postEdit').val().trim(); // PostContent
        var Post = {
            UserID: UID,
            PostContent: PC,
        };
    
        $.ajax({
            method: "POST",
            url: "api/Post/",
            data: JSON.stringify(Post),
            dataType: 'application/json',
            contentType: 'application/json',
            success: function (response) {
                if (response == true) {
                    alert("Đăng bài thành công");
                    loadData();
                }
                else {
                    alert("đăng thất bại");
                }
            },
            fail: function () {
                alert("Kết nối không thành công");
            },

        });
        debugger;
    }

})

var commmentJs = Object.create({ // load dữ liệu comment
    loadData: function () {
        $.ajax({
            method: "GET",
            url: "/api/Comment",
                success : function(data) {
                    if (data && data.length > 0) {
                        $('#allComment') = html('');
                        data.forEach(function (item, index) {
                            var itemHTML = '<div id="comment">' +
                                '<div id="commentBy">' +
                                '<img id="avatarStatus" src="../IMG/EmployeeImage.png" />' +
                                '<a href="#"><h6>' + item.FullName + '</h6></a>' +
                                '<p>' + item.CommentContent + '</p>' +
                                '</div>' +
                                '</div > ';
                            $('#allComment').append(itemHTML);
                        })
                    }
              },
            fail: function() {
                alert("không thành công");
            }

        })
    }
})