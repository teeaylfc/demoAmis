
$(document).ready(function () {
    // Load dữ liệu:
    indexJS.loadData();

    $('#btnSearch').click(indexJS.btnSearch_OnClick);
    $('#btnDelete').click(indexJS.btnDelete_OnClick);
    $('#bodyListStudent').on('click', 'tr', indexJS.row_OnClick);
});

var indexJS = Object.create({
    loadData: function () {
        $.ajax({
            method: "GET",
            url: "/api/Student",
            success: function (response) {
                $('#bodyListStudent').html('');
                // Thưc hiện build html và append vào table:
                var listStudent = response;
                listStudent.forEach(function (item, index) {
                    debugger;
                    var itemHtml = '<tr studentID=' + item.StudentID + '>' +
                        '<th scope = "row"> ' + (index + 1) + '</th>' +
                        '<td>' + item.StudentCode + '</td>' +
                        '<td>' + item.FirstName + '</td>' +
                        '<td>' + item.LastName + '</td>' +
                        '<td>' + item.Email + '</td>' +
                        '</tr >';
                    $('#bodyListStudent').append(itemHtml);
                    debugger;
                })
            },
            fail: function (response) {

            }
        });
    },
    btnSearch_OnClick: function () {
        // Lấy thông tin mã sinh viên được nhập từ textbox:
        var studentCode = $('#txtSearch').val().trim();
        // Gọi API tìm kiếm sinh viên theo mã:
        if (studentCode) {
            $.ajax({
                method: "GET",
                url: "/api/Student?studentCode=" + studentCode,
                success: function (response) {
                    $('#bodyListStudent').html('');
                    // Thưc hiện build html và append vào table:
                    var listStudent = response;
                    listStudent.forEach(function (item, index) {
                        debugger;
                        var itemHtml = '<tr>' +
                            '<th scope = "row"> ' + (index + 1) + '</th>' +
                            '<td>' + item.StudentCode + '</td>' +
                            '<td>' + item.FirstName + '</td>' +
                            '<td>' + item.LastName + '</td>' +
                            '<td>' + item.Email + '</td>' +
                            '</tr >';
                        $('#bodyListStudent').append(itemHtml);
                    })
                },
                fail: function () {
                    alert('Có lỗi xảy ra!');
                }
            })
        }
        // Hiển thị thông tin sinh viên tìm được:
    },
    row_OnClick: function () {
        $('#bodyListStudent .row-selected').removeClass('row-selected');
        $(this).addClass('row-selected');
    },

    btnDelete_OnClick: function () {
        // Lấy Id bản ghi được chọn:
        var rowSelected = $('#bodyListStudent .row-selected');
        
        if (rowSelected.length > 0) {
            var studentID = rowSelected.attr('studentID');
            $.ajax({
                method: "DELETE",
                url: "/api/Student?studentID=" + studentID,
                success: function () {
                    indexJS.loadData();
                },
                fail: function () {

                }
            })
        } else {
            alert('Bạn chưa chọn bản ghi nào!');
        }
        // Gọi Ajax thưuc hiện xóa:

        // Load lại dữ liệu:
    }
})