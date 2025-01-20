
import React from 'react';
import { useFormik } from "formik"
import {User} from "../../types/user"

import PhoneInput, { isValidPhoneNumber,formatPhoneNumber }  from 'react-phone-number-input/input'

import '../SingUp/SingUp.css';
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
// import ''

export default function SingUp()
{
   
   
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
        if (values.name == '' || !values.name)

            errors.name = "Required"
        else if (values.name.length < 2)
            errors.name = 'must by 2 char'

        if(values.lastName==''||!values.lastName)
            errors.lastName='Required'
        else if(values.lastName.length<2)
            errors.lastName='must by 2 char'
        
        if(values.phone==''||!values.phone)
            errors.phone='Required'
        else if(values.phone.length!=10 || !/^\d{1,10}$/.test(values.phone) )
            errors.phone='phone number invalid'
        return errors;

    }

    const mySubmit = (values: any) => {
        // submit פונקציה שתופעל בלחיצה על //

        const user: User = {
            userName: myFormik.values.name + " " + myFormik.values.lastName,
            email: myFormik.values.email,
            phone: myFormik.values.phone,
            password: myFormik.values.password,
            cityId: 0,
            address: '',
            soppingCardId: 1
        }
        axios.post("https://localhost:44388/api/User/AddUser",user).then
        (
            function (response) {
                console.log(response);
              }
            ).catch(
              function (error) {
                console.log(error)
              }
        );
        // _dispatch({
        //     data: user,
        //     type: "SET_USER",
        // });
        alert("signup email:" + myFormik.values.name)
    }
    const myFormik = useFormik(
        {
            initialValues: { name: '',lastName:'', email: '',phone:'', password: '',agree:false },
            validate: myCheckValidate,
            onSubmit: mySubmit,
        })

    return(
        <>
        <div>
        <div className="cont template d-flex justify-content-center align-items-center my-5 cascading-right" style={{background: 'hsla(0, 0%, 100%, 0.55)',  backdropFilter: 'blur(30px)'}}>
            <br></br>
            <div className='form_container rounded p-2 shadow-5 text-center'>
            <h1 className='text-center'> Sign Up</h1>
            <br></br>
            
            <form onSubmit={myFormik.handleSubmit} className="was-validated">

               <div className='row'>
                <div className='col-md'>
                <div className="form-group">
                    <label htmlFor="name">Name</label>
                    <input className="form-control"
                        placeholder='Enter Name'
                        id="name"
                        name="name"
                        type="name"
                        required
                        minLength={2}
                        onChange={myFormik.handleChange}
                        value={myFormik.values.name} />
                </div>
                {myFormik.errors.name ? <div className="alert alert-danger p-1 fs-6">{myFormik.errors.name}</div> : ''}
                </div>
                <div className='col-md'>
                <div className="form-group">
                    <label htmlFor="lastName">Last Name</label>
                    <input className="form-control"
                        placeholder='Enter Last Name'
                        id="lastName"
                        name="lastName"
                        type="lastName"
                        required
                        minLength={2}
                        onChange={myFormik.handleChange}
                        value={myFormik.values.lastName} />
                </div>
                {myFormik.errors.lastName ? <div className="alert alert-danger p-1 fs-6">{myFormik.errors.lastName}</div> : ''}
                </div>
                </div>
                <div className='row'>
                    <div className='col-md'>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
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
                <div className='col-md'>
                <div className="form-group ">
                    <label htmlFor="phone">Phone</label>
                    <input className="form-control"
                        id="phone"
                        name="phone"
                        type="phone"
                        // country="IL"

                        required
                        onChange={myFormik.handleChange}
                        value={myFormik.values.phone} />
                </div>
                {myFormik.errors.phone ? <div className="alert alert-danger p-1 fs-6">{myFormik.errors.phone}</div> : ''}

                </div>
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
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
                <label className="form-check-label fs-5 p-2" htmlFor="agree">
                <input className="from-control p-2" type="checkbox" onChange={myFormik.handleChange} checked={myFormik.values.agree}  id="agree"/>
                
                I agree to receive promotional mailings via e-mail and text messages
                </label>
                </div>

                <div className="form-group">
                    <button type="submit" className="btn btn-primary">Sign Up</button>
                </div>

            </form>
            <br></br>
            <div className='fs-6'>Already have an account?</div>
            {/* <Link to="/"> Login</Link> */}
            </div>
        </div>
        </div>
        </>
    )
}