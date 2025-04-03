import axios from "axios";
import { useTranslation } from "react-i18next";
import { toast, ToastContainer } from "react-toastify";

interface DeleteCategoryProps {
    handleClose: () => void;
    categoryId?: number;
    render?: () => void;
}

export default function DeleteCategoryModel({handleClose,categoryId,render}: DeleteCategoryProps){
    const { t, i18n } = useTranslation();

    const deleteCategory = () => {
        if(categoryId){
        const response = axios.delete(`https://localhost:44388/api/Category/DeleteCategory/${categoryId}`, {
            headers: {
              "Content-Type": "application/json"
            }
          }).then
            (
              function (response) {
                alert(t("delete_category"));
                handleClose()
                if(render)
                {render();}
  
              }
            ).catch(
              function (error) {
                console.log(error);
                if (error.response) {
                  console.error("Response Data:", error.response.data);
                  console.error("Status:", error.response.status);
                  console.error("Headers:", error.response.headers);
  
                }
  
                toast.error(error.response.data || "Delete Category Faild Please try again.");
              }
            );
        }

    }

    return (
    <>
    <div >
                <ToastContainer />
                <section className="modal-article ">
                    {/* <div className="create-modal-header txt-20 justify-left col-white">{t("log_out")}</div> */}
                    <div className="pt-30 pb-30 txt-18 justify-center">{t("delete_category_modal_content")}</div>
                    <div className="flex-grid2 modal-grid2-gaps modal-p">
                        <div className="btn-common mouse-cursor justify-center col-white" onClick={handleClose}>{t("cancel")}</div>
                        <div className="btn-common mouse-cursor justify-center col-white" onClick={deleteCategory}>{t("ok")}</div>
                    </div>
                </section>
            </div>
    </>
    );
}