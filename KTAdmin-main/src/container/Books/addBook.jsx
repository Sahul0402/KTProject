import React from 'react'
import { Button, Card, Col, Form, Row } from 'react-bootstrap';
import { Fragment, useState, useEffect } from 'react';
import Pageheader from '../../components/pageheader/pageheader';
import { postDataService, getDataService } from '../../services/service';
import { Multipleselectdata, Multipleselectdata1, Optionwithnosearch, SingleGroup } from '../forms/formelements/formselect/formslectdata'
import Select from 'react-select';

const addBook = () => {

    const [authorData, setAuthorData] = useState([]);

    useEffect(() => {
        BindUsers();
        //BindCategory();
    }, []);

    const BindUsers = async () => {
        debugger;
        const result = await getDataService('api/User/GetAllUser');
        setAuthorData(result);
        console.log(result);
    }
    const BindCategory = async () => {
        const result = await getDataService('api/Category/GetAllUserTypes');
        setUserTypeData(result);
    }

    const [formData, setFormData] = useState({
        address: '',
        dob: '',
    });

    const handleInputChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const onSubmit = async () => {
        debugger;
        console.log(formData);
        //const response = await postDataService('api/user/addUser', JSON.stringify(formData));
        //console.log(response);
    };

    return (
        <Fragment>
            <Pageheader title="Add User" heading="Admin Dashboard" active="Add User" />
            <div className="container-fluid">
                <Row>
                    <Col>
                        <Card className="custom-card">
                            <Card.Header className=" justify-content-between">
                                <Card.Title>
                                    Add New User
                                </Card.Title>
                            </Card.Header>
                            <Card.Body>
                                <Row>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Book Name</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Book name"
                                            aria-label="Book Name" name="book" value={formData.book}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Name</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Name"
                                            aria-label="Name" name="name" value={formData.name}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Tanglish</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Tanglish"
                                            aria-label="Tanglish" name="tanglish" value={formData.tanglish}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">

                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Author Name(ஆசிரியர்)</Form.Label>
                                        <Form.Select name="AuthorId" className="form-select" onChange={handleInputChange}>
                                            <option selected disabled="true">-- Select Author --</option>
                                            {
                                                authorData && authorData.map((item) => (
                                                    <option value={item.userId}>{item.userName}</option>
                                                ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Translator Name(மொழிபெயர்ப்பாளர்)</Form.Label>
                                        <Form.Select name="translatorId" className="form-select" onChange={handleInputChange}>
                                            <option selected disabled="true">-- Select Translator --</option>
                                            {
                                                authorData?.map((item) => (
                                                    <option value={item.userId}>{item.userName}</option>
                                                ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Text Writer Name(உரையாசிரியர்)</Form.Label>
                                        <Form.Select isMulti name="userTypeId" className="form-select">
                                            <option selected disabled="true">-- Select Text Writer --</option>
                                            {authorData?.map((item) => (
                                                <option value={item.userId}>{item.userName}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Collect Name(தொகுப்பாளர்)</Form.Label>
                                        <Select isMulti name="colors" options={authorData} className="basic-multi-select" id="choices-multiple-default"
                                            menuPlacement='auto' classNamePrefix="Select2" defaultValue={[authorData]}
                                        />
                                    </Col>

                                    <Col md={12}>
                                        <Button type="submit" variant='primary' className="" onClick={onSubmit} >Submit</Button>
                                    </Col>
                                </Row>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </div>
        </Fragment>
    )
}

export default addBook