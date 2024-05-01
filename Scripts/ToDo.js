


$(document).ready(function () {
  
    loadData();
});

function loadData() {

    $.ajax({
       
        url: "/Home/List/id",
        type: "GET",
        contentType: "application/json;charset=urf-8",
        dataType: "json",
        success: function (result) {
            
            var html = '';
            $.each(result, function (key, item) {
                console.log(item.Checkbox);
                html += '<tr class="warning">';
                if (item.Checkbox == true) {
                    html += '<td> <input type="checkbox" id="check' + item.Id + '" name="row-check" class="item-completed" checked onclick="Check(' + item.Id + ')" ></td>'
                    html += '<td class="checkedStatus">' + item.Title + '</td>';
                    html += '<td class="checkedStatus">' + item.Description + '</td>';
                    html += '<td class="checkedStatus">' + item.strCreatedDate + '</td>';
                    html += '<td id="upd" class="checkedStatus">' + item.strUpdatedDate + '</td>';
                  
                    html += '<td>  <button class="btn btn-success">Edit</button> | <button class="btn btn-danger" href="#" onclick="Delete( ' + item.Id + ')">Delete</button>'
                    '</td>';  
                   
                }
                else {
                    html += '<td> <input type="checkbox" id="check' + item.Id + '" name="row-check" class="item-completed"  onclick="Check(' + item.Id + ')" ></td>'
                    html += '<td> ' + item.Title + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td>' + item.strCreatedDate + '</td>';
                    html += '<td>' + item.strUpdatedDate + '</td>';
                 
                    html += '<td>  <button class="btn btn-success" onclick="return getbyId( ' + item.Id + ')">Edit</button> | <button class="btn btn-danger" href="#" onclick="Delete( ' + item.Id + ')">Delete</button>'
                    '</td>';  
                }
               
             

                html += '</tr>';
                $('.tbody').html(html);
               
               
            });
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}





function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var ToDoObj = {

        Title:$('#title').val(),
        Description: $('#description').val()
       
      
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(ToDoObj),
        type: "Post",
        contentType: "application/json;charset=urf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                alert("data added successfully");
                $('#myModal').modal('hide');
            }
            else {
                alert("some error occured");
               
            }
            
            loadData();
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function getbyId(id) {
    $('#title').css('border-color', 'lightgrey');
    $('#description').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Home/getbyId/" + id,
        type: "GET",
        contentType: "application/json;chatset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            
                
           $('#title').val(result.Title);
           $('#description').val(result.Description);
            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#TitleAdd').hide();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function Update() {
   
    var res = validate();
    if (res == false) {
        return false;
    }
    var todoObj = {
        Id: $('#Id').val(),
        Title: $('#title').val(),
        Description: $('#description').val(),
              
        
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(todoObj),
        type: "POST",        
        contentType: "application/json;charset=urf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
              
                alert("updated successfully");
    
                $('#myModal').modal('hide');
            }
            else {
                alert("some error occured");

            }
            
            $("Id").val("");
            $("title").val("");
            $("description").val("");
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Delete(id) {
    var ans = confirm("Are you sure you wants to delete.");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#title').val("");
    $('#description').val("");
    $('#btnUpdate').hide();
    $('#TitleUpd').hide();
    $('#btnAdd').show();
    $('#title').css('border-color', 'lightgrey');
    $('#description').css('border-color', 'lightgrey');
}


function validate() {
    var isValid = true; 
    if ($('#title').val().trim() == "") {
        $('#title').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#title').css('border-color', 'lightgrey');
    }
    if ($('#description').val().trim() == "") {
        $('#description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#description').css('border-color', 'lightgrey');
    }
    return isValid;
}



function Check(value) {
    console.log("check", value);
    let selector = "#check" + value;
    let obj = {
        "Id": value,
        "Checkbox": false
    }
    if ($(selector).is(':checked')) {
        obj.Checkbox = true;
    }
    else {
        obj.Checkbox = false
    }


    $.ajax({
        url: "/Home/checked",
        type: "POST",
        data: JSON.stringify(obj),
        contentType: "application/json;charset=urf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                alert("Data updated successfully");
            }
        }
    })
    loadData();
}

