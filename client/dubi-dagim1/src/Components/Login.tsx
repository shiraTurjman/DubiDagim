import { useState } from "react"

import { useTranslation } from "react-i18next";
import { Link, useNavigate } from "react-router-dom";
import { useUser } from "../context/UserContext";
import { useFormik } from "formik";
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from "axios";
import { UserLogin } from "../types/login";
import { toast, ToastContainer } from "react-toastify";

export default function Login() {

    const [spinning, setSpinning] = useState(false);
    const { t, i18n } = useTranslation();
    const { setRole } = useUser();

    const navigate = useNavigate();


    const myCheckValidate = (values: any) => {
        const errors: any = {};
        if (values.email == '' || !values.email)
            errors.email = "Required"
        else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
            errors.email = "Invalid"

        }
        if (values.password == '' || !values.password)


            errors.password = "Required"
        else if (values.password.length < 5 || values.password.length > 20)
            errors.password = 'must by 5-20 char'

        return errors;

    }



    const mySubmit = (values: any) => {
        // submit פונקציה שתופעל בלחיצה על //

        const userToLogin: UserLogin = {
            email: myFormik.values.email,
            password: myFormik.values.password,
        }
        // console.log("User Data:", user); 
        const response = axios.post("https://localhost:44388/api/User/Login", userToLogin, {
            headers: {
                "Content-Type": "application/json"
            }
        }).then
            (
                function (response) {
                    console.log(response);
                    localStorage.setItem("id", response.data.userId);
                    localStorage.setItem("name", response.data.userName);
                    localStorage.setItem("email", response.data.email);
debugger;
                    setRole(response.data.email == "s0527128808@gmail.com" ? "admin" : "user");
                    // localStorage.setItem("role", temp.role);
                    // localStorage.setItem("token", res.data.token);
                    navigate('/');
                }
            ).catch(
                function (error) {
                    console.log(error);
                    if (error.response) {
                        console.error("Response Data:", error.response.data);
                        console.error("Status:", error.response.status);
                        console.error("Headers:", error.response.headers);
                        
                    }
                    
                    toast.error(error.response.data || "Login failed. Please try again.");
                }
            );

        // _dispatch({
        //     data: user,
        //     type: "SET_USER",
        // });
        // alert("signup email:" + myFormik.values.name)
    }

    const myFormik = useFormik(
        {
            initialValues: { name: '', lastName: '', email: '', phone: '', password: '', agree: false },
            validate: myCheckValidate,
            onSubmit: mySubmit,
        })

    return (

        <>
            <ToastContainer />
            <div className="spinning-curtain" style={{ display: spinning ? "flex" : "none" }}>
                <div className="lds-dual-ring" />
            </div>
            <div>
                <div className="cont template d-flex justify-content-center align-items-center my-5 cascading-right" style={{ background: 'hsla(0, 0%, 100%, 0.55)', backdropFilter: 'blur(30px)' }}>
                    <br></br>
                    <div className='form_container rounded p-2 shadow-5 text-center'>
                        <h1 className='text-center'> {t("login")}</h1>
                        <br></br>

                        <form onSubmit={myFormik.handleSubmit} className="was-validated">

                            <div className='row'>
                                <div className='col-md'>
                                    <div className="form-group">
                                        <label htmlFor="email">{t("email")}</label>
                                        <input className="form-control"
                                            id="email"
                                            name="email"
                                            type="email"
                                            required
                                            onChange={myFormik.handleChange}
                                            value={myFormik.values.email} />
                                    </div>
                                    {myFormik.errors.email ? <div className="alert alert-danger p-1 fs-6">{myFormik.errors.email}</div> : ''}
                                </div>

                            </div>

                            <div className="form-group">
                                <label htmlFor="password">{t("password")}</label>
                                <input className="form-control"
                                    id="password"
                                    name="password"
                                    type="password"
                                    minLength={5}
                                    maxLength={20}
                                    required
                                    onChange={myFormik.handleChange}
                                    value={myFormik.values.password} />
                            </div>
                            {myFormik.errors.password ? <div className="alert alert-danger p-1 fs-6">{myFormik.errors.password}</div> : ''}
                            <br></br>


                            <div className="form-group">
                                <button type="submit" className="btn btn-primary">{t("login")}</button>
                            </div>

                        </form>
                        <br></br>

                        <div className='fs-6'>{t("have_not_account")}</div>
                        <Link to="/signup">{t("sing_up")}</Link>
                    </div>
                </div>
                </div>
            </>
            )
}