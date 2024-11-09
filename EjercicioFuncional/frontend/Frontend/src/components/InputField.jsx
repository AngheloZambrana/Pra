import { Field } from "formik";
import PropTypes from "prop-types";

export default function InputField({name, type, text, placeholder})
{
    return( 
        <div>
            <label htmlFor={name}>{text}</label>
            <Field name={name} type={type} placeholder={placeholder} required={true}/>
        </div>
    )
}

InputField.propTypes = {
    name: PropTypes.string,
    type: PropTypes.string,
    text: PropTypes.string,
    placeholder: PropTypes.string
};