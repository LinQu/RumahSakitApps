// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.btn-delete').on('click', function () {
    // get data from button delete
    const id = $(this).data('id');
    // Set data to Form Edit
    $('.id').val(id);
    // Call Modal Edit
    $('#modalHapus').modal('show');
});