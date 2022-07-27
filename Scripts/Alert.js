window.setTimeout(function () {
    $(".alert").fadeTo(500.50).slideUp(100, function () {
        $(this).remove();
    });
}, 2000);