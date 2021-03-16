$(document).ready(function(){
    loaddata();
    $('#dialog').hide();
    $('#dialog-child').hide();
    $('#add-employee').click(function(){
        $('#dialog').show();
        $('#dialog-child').show();
        
    })
    $('#close-dialog').click(function(){
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#dialog').click(function(){
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#button-delete').click(function(){
        $('#dialog').hide();
        $('#dialog-child').hide();
    })
    $('#button-save').click(function(){
        savedata();
    })
});

function savedata(){
    var customer = getCustomer();
    if(validateCustomer(customer)){
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "POST",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function(){
            $('#dialog').hide();
            $('#dialog-child').hide();
            alert("Thêm mới khách hàng thành công!");
            loaddata();
        }).fail(function(){

        })
    }
}

function validateCustomer(customer){
    if(customer.CustomerCode == ""){
        alert("Mã khách hàng không được để trống!");
        $('#CustomerCode').focus();
        return false;
    };
    if(customer.FullName == ""){
        alert("Mã khách hàng không được để trống!");
        $('#CustomerCode').focus();
        return false;
    }
    if(customer.PhoneNumber == ""){
        alert("Mã khách hàng không được để trống!");
        $('#CustomerCode').focus();
        return false;
    }
    
}

function getCustomer(){
    var customer = {
        "CustomerCode": $('#CustomerCode').val(),
        "FullName": $('#CustomerCode').val(),
        "Gender": $('#CustomerCode').val(),
        "Address": $('#CustomerCode').val(),
        "DateOfBirth": $('#CustomerCode').val(),
        "Email": $('#CustomerCode').val(),
        "PhoneNumber": $('#CustomerCode').val(),
        "MemberCardCode": $('#CustomerCode').val(),
        "CompanyName": $('#CustomerCode').val(),
        "CompanyTaxCode": $('#CustomerCode').val(),
        "CustomerGroupName": $('#CustomerCode').val(),
    }
    return customer;
}

function loaddata(){
    $.ajax({
        url: "http://api.manhnv.net/api/customers",
        method: "GET"
    }).done(function(data){
        $('#table-employee tbody').empty();
        for(var i=0; i<data.length; i++){
            var info = $(`<tr>
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
    }).fail(function(reponse){

    })
};