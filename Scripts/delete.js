<script type="text/javascript">
    function delete(ClassId )
    {  
        debugger;
    swal({
        title: "Are you sure?",
    text: "Are you sure that you want to delete this Order?",
    type: "warning",
    showCancelButton: true,
    closeOnConfirm: false,
    confirmButtonText: "Yes, delete it!",
    confirmButtonColor: "#ec6c62"  
            },
    function()
    {
        $.ajax({
            url: "/Classes/delete/",
            data:
            {
                "ClassId ": ClassId
            },
            type: "DELETE"
        })
            .done(function (data) {
                sweetAlert
                    ({
                        title: "Deleted!",
                        text: "Your file was successfully deleted!",
                        type: "success"
                    },
                        function () {
                            window.location.href = '/DeleteConfirmation/Details';
                        });
            })
            .error(function (data) {
                swal("Oops", "We couldn't connect to the server!", "error");
            });  
            });  
    }
</script>
