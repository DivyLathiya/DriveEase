$(document).ready(function () {

    // --- Modal Functions ---
    function showModal(modalElement) {
        if (!modalElement) return;
        $(modalElement).removeClass('modal-inactive').addClass('modal-active');
    }

    function hideModal(modalElement) {
        if (!modalElement) return;
        $(modalElement).addClass('modal-inactive').removeClass('modal-active');
    }

    // --- Admin Car Modal Logic ---
    const carModal = $('#car-modal');
    const carForm = $('#car-form');
    const carModalTitle = $('#car-modal-title');

    // Show "Add Car" modal
    $('#add-car-btn').on('click', function () {
        // Reset the form for "Add"
        carForm.trigger('reset');
        $('#car-id').val('0'); // Set ID to 0 for a new car
        carModalTitle.text('Add New Car');
        showModal(carModal);
    });

    // Show "Edit Car" modal
    $('#fleet-table-body').on('click', '.edit-car-btn', function () {
        const btn = $(this);
        
        // Get data from the data-* attributes
        const id = btn.data('id');
        const name = btn.data('name');
        const type = btn.data('type');
        const price = btn.data('price');
        const img = btn.data('img');

        // Populate the form
        $('#car-id').val(id);
        $('#car-name').val(name);
        $('#car-type').val(type);
        $('#car-price').val(price);
        $('#car-image').val(img);

        // Set title and show
        carModalTitle.text('Edit Car');
        showModal(carModal);
    });

    // Hide car modal on cancel
    $('#cancel-car-form-btn').on('click', function () {
        hideModal(carModal);
    });

    // --- Success Message Auto-Hide ---
    const messageBox = $('#message-box');
    if (messageBox.length) {
        setTimeout(() => {
            hideModal(messageBox);
        }, 3000); // Hide after 3 seconds
    }
});
