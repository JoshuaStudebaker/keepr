import Swal from "sweetalert2";

export default class SweetAlert {
  static async sweetDelete(
    title = "Are you sure you want to delete this keep!?",
    text = "It will be gone forever",
    confirm = "Yes, close it down!"
  ) {
    try {
      let res = await Swal.fire({
        title: title,
        text: text,
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#DC3545",
        cancelButtonColor: "#28A745",
        confirmButtonText: confirm,
      });
      if (res.value) {
        return true;
      }
    } catch (error) {}
  }

  static toast(title = "You did a thing", timer = 3000) {
    Swal.fire({
      title: title,
      icon: "success",
      timer: timer,
      toast: true,
      position: "top-right",
      showConfirmButton: false,
    });
  }
}
