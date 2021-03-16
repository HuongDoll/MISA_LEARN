var isEdit;
var editid;
$(document).ready(function() {
    loaddata();
    $('#dialog').hide();
    $('#dialog-child').hide();
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
    $('#close-dialog').click(function() {
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#dialog').click(function() {
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#button-delete').click(function() {
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#button-save').click(function() {
        if (isEdit) editdata();
        else savedata();
    })
    $('table tbody').on('dblclick', 'tr', function() {
        var id = $(this).attr('recordId');
        deleteItem(id);
    })
    $('table tbody').on('click', 'tr', function() {
        var id = $(this).attr('recordId');
        editItem(id);
    })
});

function editItem(id) {
    isEdit = true;
    editid = id;
    $.ajax({
        url: 'http://api.manhnv.net/api/customers/' + id,
        method: "GET"
    }).done(function(result) {
        $('#CustomerCode').val(result.CustomerCode),
            $('#FullName').val(result.FullName),
            $('#Gender').val(result.Gender),
            $('#Address').val(result.Address),
            $('#DateOfBirth').val(result.DateOfBirth),
            $('#Email').val(result.Email),
            $('#PhoneNumber').val(result.PhoneNumber),
            $('#MemberCardCode').val(result.MemberCardCode),
            $('#CompanyName').val(result.CompanyName),
            $('#CompanyTaxCode').val(result.CompanyTaxCode),
            $('#CustomerGroupName').val(result.CustomerGroupName)
        $('#dialog').show();
        $('#dialog-child').show();

    }).fail(function() {

    })
}

function editdata() {
    var customer = getCustomer();
    customer.CustomerId = editid;
    console.log(customer);
    if (validateCustomer(customer) && customer.CustomerId != "") {
        $.ajax({
            url: 'http://api.manhnv.net/api/customers/' + editid,
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

function deleteItem(id) {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers/' + id,
        method: "DELETE"
    }).done(function() {
        alert("succcc");
        loaddata();
    }).fail(function() {

    })
}

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

        })
    }
}

function validateCustomer(customer) {
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
    }
    return true;
}

function getCustomer() {
    var customer = {
        "CustomerCode": $('#CustomerCode').val(),
        "FullName": $('#FullName').val(),
        "Gender": $('#Gender').val(),
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

function loaddata() {
    $.ajax({
        url: "http://api.manhnv.net/api/customers",
        method: "GET"
    }).done(function(data) {
        $('#table-employee tbody').empty();
        for (var i = 0; i < data.length; i++) {
            var info = $(`<tr recordId="${data[i].CustomerId}">
                <td class="wight-2">${data[i].CustomerCode}</td>
                <td class="wight-3">${data[i].FullName}</td>
                <td class="wight-1">${data[i].Gender}</td>
                <td class="wight-1">${data[i].DateOfBirth}</td>
                <td class="wight-2">${data[i].CustomerGroupName}</td>
                <td class="wight-1">${data[i].PhoneNumber}</td>
                <td class="wight-3">${data[i].Email}</td>
                <td class="wight-3">${data[i].Address}</td>
                <td class="wight-1">${data[i].MemberCardCode}</td>
            </tr>`);
            info.data("id", data[i].CustomerId);
            $('#table-employee > tbody:last-child').append(info);
        }
    }).fail(function(reponse) {

    })
};