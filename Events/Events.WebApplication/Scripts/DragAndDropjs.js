function galleryDragAndDrop(mainContainer, containerOne, containerTwo, dragItem) {
    $(dragItem).draggable(
        {
            revert: "invalid",
            containment: mainContainer,
            helper: "clone",
            cursor: "move",
            drag: function (event, ui) {
                $(ui.helper.prevObject).addClass("box_current");
            },
            stop: function (event, ui) {
                $(ui.helper.prevObject).removeClass("box_current");
            }
        });

    $(containerTwo).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            acceptBoxIngalleryTwo(ui.draggable);
        }
    });

    $(containerOne).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            acceptBoxIngalleryOne(ui.draggable);
        }
    });

    function acceptBoxIngalleryTwo(item) {
        $(item).fadeOut(function () {
            $(containerTwo).append(item);
        });

        $(item).fadeIn();
        $(item).removeClass("box_current");
    }

    function acceptBoxIngalleryOne(item) {
        $(item).fadeOut(function () {
            $(containerOne).append(item);
        });

        $(item).fadeIn();
        $(item).removeClass("box_current");
    }
}