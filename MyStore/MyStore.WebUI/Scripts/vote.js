var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();
$("#confirmVoteButton").click(function () {
    $('#voteFailure').hide();
    $('#progressBar').show();

    var userID = $(this).attr("data-user-id");
    var productID = $(this).attr("data-product-id");
    var votes = $(this).attr("data-votes");
    var totalVotes = $(this).attr("data-total-votes");
    var comments = $('#comments').val();
    var firstName = $(this).attr("data-first-name");
    var lastName = $(this).attr("data-last-name");

    var token = $('[name="__RequestVerificationToken"]').val();
    var csrfHeader = { 'X-Csrf-Token': token };

    //todo: Session-9.2 Cross Site Request Forgery Fix (API) - JS
    delay(function () {
        $.ajax({
            url: '../api/vote',
            type: 'POST',
            //headers: csrfHeader,
            data: { userID: userID, productID: productID, comments:comments}
        }).fail(function () {
                $('#progressBar').hide();
                $('#voteFailure').show();
            })
            .done(function () {
                $('#voteButton').hide();
                $('#voteContainer').html('Thank you for voting!');
                $("#voteContainer").addClass('alert alert-success');
                $('#voteModal').modal('hide');

                votes++;
                totalVotes++;

                $('#votesHeading').text(votes + ' ' + (votes === 1 ? 'vote' : 'votes') + ' out of ' + totalVotes + ' total');
                $('#voteBar').css('width', votes / totalVotes * 100 + '%');
                if (comments !== '') {
                    $('#results tr:last')
                        .after('<tr><td>' + firstName + ' ' + lastName + '</td><td>' + comments + '</td></tr>');
                }

            });
    }, 700);
});

$('#voteModal').on('hidden', function () {
    $('#voteFailure').hide();
});


function htmlEncode(value) {
    return $('<div/>').text(value).html();
}

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}