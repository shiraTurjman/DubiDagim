import { ToastContainer } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { useUser } from "../context/UserContext";
import '../assets/css/dashboard.css';

interface LogOutProps {
    handleClose: () => void;
}

export default function LogOut (props: LogOutProps) {
  const { t, i18n } = useTranslation();
  const { setRole } = useUser();
 
  const logOut = () => {
    localStorage.setItem("id", '');
    localStorage.setItem("name", '');
    localStorage.setItem("email", '');
    localStorage.setItem("role", '');
    setRole(null);
    props.handleClose(); 
};
  
    return (
      
        <div >
                <ToastContainer />
                <section className="modal-article ">
                    {/* <div className="create-modal-header txt-20 justify-left col-white">{t("log_out")}</div> */}
                    <div className="pt-30 pb-30 txt-18 justify-center">{t("delete_logout_modal_content")}</div>
                    <div className="flex-grid2 modal-grid2-gaps modal-p">
                        <div className="btn-common mouse-cursor justify-center col-white" onClick={props.handleClose}>{t("cancel")}</div>
                        <div className="btn-common mouse-cursor justify-center col-white" onClick={logOut}>{t("ok")}</div>
                    </div>
                </section>
            </div>
     
    );
  };
  