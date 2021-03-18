var isEdit; // xác định thay đổi thông tin khách hàng hay thêm mới khách hàng
var selectid; // lưu trữ id khách hàng
$(document).ready(function() {
    // load thông tin khách hàng vào table
    loaddata();

    // ẩn dialog nhập thông tin khách hàng
    $('#dialog').hide();
    $('#dialog-child').hide();

    // ẩn dialog tùy chọn sửa xóa thông tin khách hàng
    $('#mini-dialog').hide();
    $('#mini-select').hide();

    $('#mini-dialog').click(function() {
        $('#mini-dialog').hide();
        $('#mini-select').hide();
    })

    // action cho button thêm khách hàng
    $('#add-employee').click(function() {
            isEdit = false;
            $('#dialog').show();
            $('#dialog-child').show();
            $('#CustomerCode').val(""),
                $('#FullName').val(""),
                $('#Gender').val(""),
                $('#Address').val(""),
                $('#DateOfBirth').val(""),
                $('#Email').val(""),
                $('#PhoneNumber').val(""),
                $('#MemberCardCode').val(""),
                $('#CompanyName').val(""),
                $('#CompanyTaxCode').val(""),
                $('#CustomerGroupName').val("")
        })
        // button tắt dialog
    $('#close-dialog').click(function() {
            $('#dialog').hide();
            $('#dialog-child').hide();
        })
        // tắt dialog khi ấn ra ngoài form
    $('#dialog').click(function() {
            $('#dialog').hide();
            $('#dialog-child').hide();
        })
        // button hủy 
    $('#button-delete').click(function() {
            $('#dialog').hide();
            $('#dialog-child').hide();
        })
        // button lưu thông tin
    $('#button-save').click(function() {
            if (isEdit) editdata();
            else savedata();
        })
        // button refresh
    $('#button-refresh').click(function(){
        loaddata();
    })
        // action khi double click vào 1 phần tử trong bảng
    $('table tbody').on('dblclick', 'tr', function() {
            selectid = $(this).attr('recordId');
            console.log($(this).position());
            var top = $(this).position().top + 210;
            var left = $(this).position().left + 120;
            $('#mini-select').css({ top: top, left: left, position: 'absolute' });
            $('#mini-dialog').show();
            $('#mini-select').show();
        })
        // action cho button sửa thông tin khách hàng
    $('#button-edit').click(function() {
            $('#mini-dialog').hide();
            $('#mini-select').hide();
            editItem(selectid);
        })
        // action cho button xóa thông tin khách hàng
    $('#button-delete-item').click(function() {
        $('#mini-dialog').hide();
        $('#mini-select').hide();
        if (confirm("Bạn chắc chắn muốn xóa thông tin khách hàng???")) {
            deleteItem(selectid);
        }
    })
    $("#input-filter").on("keyup", function() {
        var value = $(this).val().toLowerCase();
        $("#table-employee tbody tr").filter(function() {
          $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
      });

});
// function sửa khách hàng
function editItem(selectid) {
    isEdit = true;
    //lấy thông tin khách hàng 
    $.ajax({
        url: 'http://api.manhnv.net/api/customers/' + selectid,
        method: "GET"
    }).done(function(result) {
        console.log(result);
        $('#CustomerCode').val(result.CustomerCode);
        $('#FullName').val(result.FullName);
        if(result.Gender != null) $('input[type="radio"][name="Gender"][value='+result.Gender+']').prop('checked', 'checked');
        $('#Address').val(result.Address);
        $('#DateOfBirth').val(formatDatee(result.DateOfBirth));
        $('#Email').val(result.Email);
        $('#PhoneNumber').val(result.PhoneNumber);
        $('#MemberCardCode').val(result.MemberCardCode);
        $('#CompanyName').val(result.CompanyName);
        $('#CompanyTaxCode').val(result.CompanyTaxCode);
        $('#CustomerGroupName').val(result.CustomerGroupName);
        // hiển thị hộp thoại sửa thông tin
        $('#dialog').show();
        $('#dialog-child').show();

    }).fail(function() {

    })
}
// sửa thông tin khách hàng trong data
function editdata() {
    var customer = getCustomer();
    customer.CustomerId = selectid;
    console.log(customer);
    if (validateCustomer(customer) && customer.CustomerId != "") {
        $.ajax({
            url: 'http://api.manhnv.net/api/customers/' + selectid,
            method: "PUT",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function() {
            $('#dialog').hide();
            $('#dialog-child').hide();
            loaddata();
            alert("Chỉnh sửa thông tin khách hàng thành công!");
        }).fail(function() {

        })
    }
}
// xóa thông tin khách hàng dựa theo id
function deleteItem(id) {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers/' + id,
        method: "DELETE"
    }).done(function() {
        alert("Xóa khách hàng thành công!");
        loaddata();
    }).fail(function() {

    })
}
// lưu thông tin khách hàng nhập từ form
function savedata() {
    var customer = getCustomer();
    if (validateCustomer(customer)) {
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "POST",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function() {
            $('#dialog').hide();
            $('#dialog-child').hide();
            loaddata();
            alert("Thêm mới khách hàng thành công!");
        }).fail(function() {
            alert("Có lỗi xảy ra!");
        })
    }
}
// validate thông tin nhập vào từ form
function validateCustomer(customer) {
    var phonenumber = /^\d{10}$/;
    var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (customer.CustomerCode == "") {
        alert("Mã khách hàng không được để trống!");
        $('#CustomerCode').focus();
        return false;
    }
    if (customer.FullName == "") {
        alert("Họ và tên không được để trống!");
        $('#FullName').focus();
        return false;
    }
    if (customer.PhoneNumber == "") {
        alert("Số điện thoại không được để trống!");
        $('#PhoneNumber').focus();
        return false;
    }else{
        if(!customer.PhoneNumber.match(phonenumber)){
            alert("Nhập đúng số điện thoại!");
            $('#PhoneNumber').focus();
            return false;
        }
    }
    // if(customer.Email != "" && !customer.Email.match(mailformat)){
    //     alert("Nhập đúng email!");
    //     $('#Email').focus();
    //     return false;
    // }

    return true;
}
// lấy thông tin nhập từ form
function getCustomer() {
    var customer = {
        "CustomerCode": $('#CustomerCode').val(),
        "FullName": $('#FullName').val(),
        "Gender": $("input[type='radio'][name='Gender']:checked").val(),
        "Address": $('#Address').val(),
        "DateOfBirth": $('#DateOfBirth').val(),
        "Email": $('#Email').val(),
        "PhoneNumber": $('#PhoneNumber').val(),
        "MemberCardCode": $('#MemberCardCode').val(),
        "CompanyName": $('#CompanyName').val(),
        "CompanyTaxCode": $('#CompanyTaxCode').val(),
        "CustomerGroupName": $('#CustomerGroupName').val(),
    }
    return customer;
}
// format lại ngày tháng năm sinh
function formatDate(datee) {
    if(datee != null){
        var date = new Date(datee);
        var year = date.getFullYear();
    
        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
    
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
    
        return day + "/" + month + "/" + year;
    }else return null;
    
}
function formatDatee(datee) {
    if(datee != null){
        var date = new Date(datee);
        var year = date.getFullYear();
    
        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
    
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
    
        return year + "-" + month + "-" + day;
    }else return null;
    
}
// format lại giới tính
function formatGender(gender) {
    if (gender == 1) return "Nam";
    else {
        if (gender == 2) return "Nữ";
        else return "Khác";
    }
}

// tải thông tin khách hàng từ api
function loaddata() {
    $.ajax({
        url: "http://api.manhnv.net/api/customers",
        method: "GET"
    }).done(function(data) {
        $('#table-employee tbody').empty();
        for (var i = 0; i < data.length; i++) {
            var info = $(`<tr recordId="${data[i].CustomerId}">
                <td class="wight-2">${data[i].CustomerCode}</td>
                <td class="wight-2">${data[i].FullName}</td>
                <td class="wight-1">${formatGender(data[i].Gender)}</td>
                <td class="wight-2">${formatDate(data[i].DateOfBirth)}</td>
                <td class="wight-2">${data[i].CustomerGroupName}</td>
                <td class="wight-1">${data[i].PhoneNumber}</td>
                <td class="wight-2">${data[i].Email}</td>
                <td class="wight-3">${data[i].Address}</td>
                <td class="wight-1">${data[i].MemberCardCode}</td>
            </tr>`);
            info.data("id", data[i].CustomerId);
            $('#table-employee > tbody:last-child').append(info);
        }
    }).fail(function(reponse) {

    })
};