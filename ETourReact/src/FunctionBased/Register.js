import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";

const RegistrationForm = () => {
  const [validated, setValidated] = useState(false);
  const[newdata, setNewdata] = useState({});
  // const [formData, setFormData] = useState({
  //   name: "",
  //   address:"",
  //   email: "",
  //   mobile: "",
  //   age:"",
  //   password: "",
  //   gender: "",
  // });

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }
    setValidated(true);

    let data = JSON.stringify(newdata);
  
  fetch("https://localhost:7200/api/Customer_Master", {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: data,
    }).then((res) => res.json())
    .then((res)=> alert("register successfully"))
    .catch(error=>alert("register unsuccessful"));
  };

  // const handleChange = (event) => {
  //   const { name, value } = event.target;
  //   // console.log(event.target.name)
  //   setData((prevState) => ({
  //     ...prevState,
  //     [name]: value,
  //   }));
  // };
  const handleChange = (event) =>{
    const name = event.target.name;
    const value = event.target.value;
    setNewdata(values => ({...values, [name]:value}))
}

  return (
    <Form noValidate validated={validated} onSubmit={handleSubmit}>
      <Form.Group controlId="formBasicName">
        <Form.Label>Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter name"
          name="customerName"
          // value={formData.name}
          onBlur={handleChange}
          required
        />
        <Form.Control.Feedback type="invalid">
          Please enter your name.
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group controlId="formBasicAddress">
        <Form.Label>Address</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter Address"
          name="address"
          // value={formData.address}
          onBlur={handleChange}
          required
        />
        <Form.Control.Feedback type="invalid">
          Please enter your address.
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group controlId="formBasicEmail">
        <Form.Label>Email address</Form.Label>
        <Form.Control
          type="email"
          placeholder="Enter email"
          name="email"
          // value={formData.email}
          onBlur={handleChange}
          // pattern="[a-z0-9]+@[a-z0-9.]+\.[a-z]$"
          required
        />
        <Form.Control.Feedback type="invalid">
          Please enter a valid email address.
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group controlId="formBasicMobile">
        <Form.Label>Mobile number</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter mobile number"
          name="phoneNumber"
          // value={formData.mobile}
          onBlur={handleChange}
          pattern="[0-9]{10}"
          required
        />
        <Form.Control.Feedback type="invalid">
          Please enter a valid 10-digit mobile number.
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group controlId="formBasicAge">
        <Form.Label>Age</Form.Label>
        <Form.Control
          type="number"
          placeholder="Enter Age"
          name="age"
          // value={formData.age}
          onBlur={handleChange}
          pattern="[0-9]{2}"
          required
        />
      </Form.Group>

      <Form.Group controlId="formBasicCountryCode">
        <Form.Label>Country Code</Form.Label>
        <Form.Control
          type="number"
          placeholder="Enter Country Code"
          name="countryCode"
          // value={formData.age}
          onBlur={handleChange}
          pattern="[0-9]{2}"
          required
        />
      </Form.Group>

      <Form.Group controlId="formBasicPassword">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          placeholder="Enter password"
          name="password"
          // value={formData.password}
          onBlur={handleChange}
          required
        />
        {/* <Form.Control.Feedback type="invalid">
          Please enter a valid password. It should be at least 8 characters long and include at least one lowercase letter, one uppercase letter, and one number.
        </Form.Control.Feedback> */}
      </Form.Group>

      <Form.Group controlId="formBasicGender">
      <Form.Label>Gender</Form.Label>
      <Form.Select
        name="gender"
        // value={formData.gender}
        onBlur={handleChange}
        required
      >
        <option value="">Choose...</option>
        <option value="male">Male</option>
        <option value="female">Female</option>
      </Form.Select>
      <Form.Control.Feedback type="invalid">
        Please choose a gender.
      </Form.Control.Feedback>
    </Form.Group>

      <Form.Group controlId="formBasicProofId">
      <Form.Label>Id Proof</Form.Label>
      <Form.Select
        name="idVerificationType"
        // value={formData.gender}
        onBlur={handleChange}
        required
      >
        <option value="">Choose...</option>
        <option value="Aadhar Card">Aadhar Card</option>
        <option value="Pan Card">Pan Card</option>
        <option value="Driving Licence">Driving Licence</option>
      </Form.Select>
      <Form.Control.Feedback type="invalid">
        Please choose a Id Proof.
      </Form.Control.Feedback>
    </Form.Group>

      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
    
  );
};

export default RegistrationForm