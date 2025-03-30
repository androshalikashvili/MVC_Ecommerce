//var dataTable;

//document.addEventListener('DOMContentLoaded', function () {
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            url: '/admin/product/getall',
//            dataSrc: function (json) {
//                return json.data;
//            }
//        },

//        columns: [
//            { data: 'name', width: "25%" },
//            { data: 'price', width: "12%" },
//            { data: 'category.name', width: "12%" },
//            {
//                data: 'id',
//                width: "25%",
//                render: function (data) {
//                    return `
//                    <div class="w-75 btn-group" role="group">
//                        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
//                        <a onClick="Delete('/admin/product/delete/${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete</a>                        
//                    </div>`;
//                }
//            }
//        ]
//    });
//}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    if (data.message) {
                        toastr.success(data.message);
                    } else {
                        toastr.success("Deleted successfuly!");
                    }
                }

            })
        }
    })
}


function addToCart(productId) {
    fetch(`/Customer/CartItem/AddToCart?productId=${productId}`, { method: 'POST' })
        .then(response => response.json())
        .then(data => {
            if (data.success !== undefined && data.success) {
                toastr.success(data.message);
                updateCartCount();
            } else {
                toastr.error("Error adding product.");
            }
        })
        .catch(error => console.error('Error loading cart:', error));
}

function updateCartCount() {
    fetch('/Customer/CartItem/GetCartCount')
        .then(response => response.json())
        .then(data => {
            let cartCountElem = document.getElementById("cart-count");
            if (cartCountElem) {
                cartCountElem.innerText = data.count;
            }
        })
        .catch(error => console.error('Error loading cart:', error));
}
