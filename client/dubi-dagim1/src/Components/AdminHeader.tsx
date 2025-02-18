import { useTranslation } from "react-i18next";
import '../assets/css/header.css';
import { useState } from "react";
import { useUser } from "../context/UserContext";
import ArrowDropDownRoundedIcon from '@mui/icons-material/ArrowDropDownRounded';
import ArrowDropUpRoundedIcon from '@mui/icons-material/ArrowDropUpRounded';
import { Link } from "react-router-dom";
import LogOut from "./Logout_model";
import Logo from '../img/logo.png';
import ShoppingCartOutlinedIcon from '@mui/icons-material/ShoppingCartOutlined';

export default function AdminHeader () {
  const { t , i18n } = useTranslation();
  const [scrolling,setScrolling] = useState(false);
  const { role } = useUser() || null;
  const [lang, setLang] = useState(i18n.language) || "en";
  const [showModalLogout, setShowModelLogout] = useState(false);
  
  const showModal = () => {
    setShowModelLogout(true);
  };
  const hideModal = () => {
    setShowModelLogout(false);
  };

    return (
      <div
        style={{
          zIndex: 3000,
          position: "absolute",
        }}
      >
        <div className={`header-body ${scrolling ? "white" : ""}`}>
          <div
            className={`header-height ${scrolling ? "white" : ""}`}
          >
            <div className="logo-mw flex-space">
              <div className={"header-logo"}>

                <div
                  // className="col-selected-bg txt-bold flex-center"
                  // style={{ padding: "10px" }}
                >
                  <ShoppingCartOutlinedIcon color="primary"/>
                <div className="btn-navbar mouse-cursor dropdown">
                {i18n.language ==="he" ? "! ": ""} {t("hi")} {role === null ? t("guest") : localStorage.name }{i18n.language ==="en"? " !": ""}
                <ArrowDropDownRoundedIcon/>
                <div className="dropdown-content">
                  {role === null ? 
                  <>
                  <Link className="btn-underLine" to="/login">
                      <div className="menu-txt mouse-cursor">
                        {t("login")}
                      </div>
                    </Link>
                    <Link className="btn-underLine" to="/signup">
                      <div className="menu-txt mouse-cursor">
                        {t("sign_up")}
                      </div>
                    </Link>
                  </>:
                  <>
                  <Link className="btn-underLine" to="/profile">
                      <div className="menu-txt mouse-cursor">
                        {t("profile")}
                      </div>
                    </Link>
                    <Link className="btn-underLine" to="/myOurder">
                      <div className="menu-txt mouse-cursor">
                        {t("my_order")}
                      </div>
                    </Link>
                    
                      <div className=" menu-txt mouse-cursor"
                      onClick={showModal}>
                        {t("log_out")}
                      </div>
                    
                    {/* <div
                    className="btn-underLine btn-navbar mouse-cursor btn-sign"
                    
                  >
                    {t("log_out")}
                  </div> */}
                  </>}
                  </div>
                </div>
                </div>
              </div>
              <div className="justify-center">
                <div className="flex-center">
                  
                    <>
                    <Link className="btn-underLine" to="/">
                        <div className="btn-navbar mouse-cursor">
                          {t("home")}
                        </div>
                      </Link>
                      <Link className="btn-underLine" to="/aboutUs">
                        <div className="btn-navbar mouse-cursor">
                          {t("about_us")}
                        </div>
                      </Link>
                      <div className="btn-navbar mouse-cursor dropdown">
                        <span>{t("our_fish")}</span>
                        <ArrowDropDownRoundedIcon/>
                        <div className="dropdown-content">
                          {/*
                          category.map((item)=> return 
                            <Link className="btn-underLine" to="/category/"+item.categoryId>
                            <div className="menu-txt mouse-cursor">
                              {item.name}
                            </div>
                          </Link>
                          )
                          */ }
                          
                        </div>
                      </div>

                      <Link className="btn-underLine" to="/sale">
                        <div className="btn-navbar mouse-cursor">
                          {t("sale")}
                        </div>
                      </Link>

                      <Link className="btn-underLine" to="/contactUs">
                        <div className="btn-navbar mouse-cursor">
                          {t("contact_us")}
                        </div>
                      </Link>

                      <Link className="btn-underLine" to="/setting">
                        <div className="btn-navbar mouse-cursor">
                          {t("settings")}
                        </div>
                      </Link>
                      <Link className="btn-underLine" to="/dashboard">
                        <div className="btn-navbar mouse-cursor">
                          {t("dashboard")}
                        </div>
                      </Link>
                      {/* <Link className="btn-underLine" to="/dashboard">
                        <div className="btn-navbar mouse-cursor">
                          {t("dashboard")}
                        </div>
                      </Link>
                      <Link className="btn-underLine" to="/settings">
                        <div className="btn-navbar mouse-cursor">
                          {t("settings")}
                        </div>
                      </Link> */}

                    </>

                  <div className="btn-navbar mouse-cursor dropdown">
                    <span>{t("language")}</span>
                    <ArrowDropDownRoundedIcon/>
                    <div className="dropdown-content">
                      <div
                        className="btn-underLine"
                        onClick={() => {i18n.changeLanguage("en")}}
                      >
                        <div className="menu-txt mouse-cursor">
                          <label className="container-event language" >
                          {/* i18n.language */}
                            {t("english")}
                          </label>
                        </div>
                      </div>
                      <div
                        className="btn-underLine"
                        onClick={() => {i18n.changeLanguage("he")}}
                      >
                        <div className="menu-txt mouse-cursor">
                          <label className="container-event language">
                            {t("hebrew")}
                          </label>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div>
                  <img 
                    src={Logo}
                    width="100"
                    height="100"
                    className="logo-mw flex-space"
                    alt="logo"></img>
                  </div>
                  
                </div>
                
              </div>
            </div>
          </div>
          
          {/*  Modal  */}
         {showModalLogout && <LogOut handleClose={hideModal}  />}
          {/*  */}
          
        </div>
      </div>
    );
  };
  

  