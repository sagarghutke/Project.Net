import * as Yup from 'yup';
import { useState } from 'react';
import { Button } from 'react-bootstrap'; // import the Button component from react-bootstrap

function LoginForm() {
  const [loginForm, setLoginForm] = useState({
    email: '',
    password: '',
  });
  const [formErrors, setFormErrors] = useState({});
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setLoginForm({ ...loginForm, [name]: value });
  };

  const handleFormSubmit = async (event) => {
    event.preventDefault();
    setIsSubmitting(true);
    try {
      await validationSchema.validate(loginForm, { abortEarly: false });
      // login form is valid, do something here
    } catch (validationErrors) {
      const errors = {};
      validationErrors.inner.forEach((error) => {
        errors[error.path] = error.message;
      });
      setFormErrors(errors);
    } finally {
      setIsSubmitting(false);
    }
  };

  const validationSchema = Yup.object().shape({
    email: Yup.string()
      .email('Please enter a valid email address')
      .required('Email address is required'),
    password: Yup.string()
      .required('Password is required')
      .min(6, 'Password must be at least 6 characters'),
  });

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <label htmlFor="email">Email Address</label>
        <input
          type="email"
          name="email"
          value={loginForm.email}
          onChange={handleInputChange}
        />
        {formErrors.email && <span>{formErrors.email}</span>}
      </div>
      <div>
        <label htmlFor="password">Password</label>
        <input
          type="password"
          name="password"
          value={loginForm.password}
          onChange={handleInputChange}
        />
        {formErrors.password && <span>{formErrors.password}</span>}
      </div>
      <Button variant="primary" onClick={handleFormSubmit}>
        Submit
      </Button>
      <Button  href="/RegistrationForm">
        SignUp
      </Button>
    </form>
  );
}

export default LoginForm;
