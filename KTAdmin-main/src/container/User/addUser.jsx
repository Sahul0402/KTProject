import { Fragment, useState, useEffect } from 'react';
import { Button, Card, Col, Form, Row } from 'react-bootstrap';
import Pageheader from '../../components/pageheader/pageheader';
import { postDataService, getDataService } from '../../services/service';

const AddUser = () => {
    const [professionData, setProfessionData] = useState([]);
    const [userTypeData, setUserTypeData] = useState([]);
    const [specialNameData, setSpecialNameData] = useState([]);
    const [countryData, setCountryData] = useState([]);
    const [stateData, setStateData] = useState([]);
    const [cityData, setCityData] = useState([]);
    const [cityId, setCityId] = useState([]);
    useEffect(() => {
        // Bind Master data in dropdown
        BindProfession();
        BindUserType();
        BindSpecialName();
        BindCountry();
    }, []);

    const BindProfession = async () => {
        const result = await getDataService('api/Master/GetAllProfession');
        setProfessionData(result);
    }
    const BindUserType = async () => {
        const result = await getDataService('api/Master/GetAllUserTypes');
        setUserTypeData(result);
    }
    const BindSpecialName = async () => {
        const result = await getDataService('api/Master/GetAllSpecialName');
        setSpecialNameData(result);
    }
    const BindCountry = async () => {
        const result = await getDataService('api/Master/GetAllCountries');
        setCountryData(result);
    }

    const getState = async (e) => {
        let countryId = e.target.value;
        const result = await getDataService('api/Master/GetStatesByCountryID',countryId);
        setStateData(result);
    }

    const getCity = async(e)=>{
        let stateId = e.target.value;
        const result = await getDataService('api/Master/GetCityByStateID',countryId);
        setCityData(result);
    }
    const setCity = async(e)=>{
        let cityId = e.target.value;
        setCityId(cityId);
        console.log(e)
    }
    const [formData, setFormData] = useState({
        address: '',
        dob: '',
        blog:'',
        email:'',
        faceBook:'',
        instagram:'',
        mobile:'',
        name:'',
        password:'',
        professionId:'',
        specialNameId:'',
        twitter:'',
        username:'',
        userTypeId:'',
        website:'',
        wikipedia:'',
        youTube:'',
        cityId:''
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

    const fetchData = async () => {
        try {
            const result = await getDataService('api/User/GetAllUser');
            setApiData(result);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
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
                                        <Form.Label className="">User Name</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="User name"
                                            aria-label="User Name" name="userName" value={formData.userName}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Name</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Name"
                                            aria-label="Name" name="name" value={formData.name}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Email</Form.Label>
                                        <Form.Control type="email" className="form-control" placeholder="Email"
                                            aria-label="Email" name="email" value={formData.email}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Password</Form.Label>
                                        <Form.Control type="password" className="form-control" placeholder="Password"
                                            aria-label="Password" name="password" value={formData.password}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Mobile</Form.Label>
                                        <Form.Control type="number" className="form-control" placeholder="Mobile"
                                            aria-label="Mobile" name="mobile" value={formData.mobile}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Profession</Form.Label>
                                        <Form.Select name="professionId" className="form-select" onChange={handleInputChange}>
                                            <option selected disabled="true">-- Select Profession --</option>
                                            {
                                                professionData && professionData.map((item) => (
                                                    <option value={item.professionId}>{item.name}</option>
                                                ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">User Type</Form.Label>
                                        <Form.Select name="userTypeId" className="form-select" onChange={handleInputChange}>
                                            <option selected disabled="true">-- Select UserType --</option>
                                            {userTypeData?.map((item) => (
                                                <option value={item.userTypeId}>{item.name}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Special Name</Form.Label>
                                        <Form.Select name="specialNameId" className="form-select" onChange={handleInputChange}>
                                            <option selected disabled="true">-- Select Special Name --</option>
                                            {specialNameData?.map((item) => (
                                                <option value={item.specialNameId}>{item.name}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Website</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Website"
                                            aria-label="Website" name="website" value={formData.website}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Blog</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Blog"
                                            aria-label="Blog" name="blog" value={formData.blog}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">FaceBook</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="FaceBook"
                                            aria-label="FaceBook" name="faceBook" value={formData.faceBook}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Twitter</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Twitter"
                                            aria-label="Twitter" name="twitter" value={formData.twitter}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Instagram</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Instagram"
                                            aria-label="Instagram" name="instagram" value={formData.instagram}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Pinterest</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Pinterest"
                                            aria-label="Pinterest" name="pinterest" value={formData.pinterest}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">YouTube</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="YouTube"
                                            aria-label="YouTube" name="youTube" value={formData.youTube}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Wikipedia</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Wikipedia"
                                            aria-label="Wikipedia" name="wikipedia" value={formData.wikipedia}
                                            onChange={handleInputChange} />
                                    </Col>

                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Date of Birth</Form.Label>
                                        <Form.Control type="date" className="form-control" placeholder="Date of Birth"
                                            aria-label="Date of Birth" name="DOB" value={formData.dob}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">DOD</Form.Label>
                                        <Form.Control type="date" className="form-control" placeholder="DOD"
                                            aria-label="DOD" name="DOD" value={formData.dod}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Comments Image</Form.Label>
                                        <Form.Control type="file" className="form-control" placeholder="ImgComments"
                                            aria-label="ImgComments" value={formData.imgComments}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Profile Image</Form.Label>
                                        <Form.Control type="file" className="form-control" placeholder="ImgProfile"
                                            aria-label="ImgProfile" value={formData.imgProfile}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Address</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Address"
                                            aria-label="Address" name="address" value={formData.address}
                                            onChange={handleInputChange} />
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">Country</Form.Label>
                                        <Form.Select id="countryId" className="form-select" onChange={(e) => getState(e)}>
                                            <option selected disabled="true">-- Select Country --</option>
                                            {countryData?.map((item) => (
                                                <option value={item.countryId}>{item.name}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">State</Form.Label>
                                        <Form.Select id="stateId" className="form-select" onChange={(e) => getCity(e)}>
                                            <option selected disabled="true">-- Select State --</option>
                                            {stateData?.map((item) => (
                                                <option value={item.stateId}>{item.name}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Label className="">City</Form.Label>
                                        <Form.Select value={formData.cityId} name="cityId" className="form-select" onChange={(e) => setCity(e)}>
                                            <option selected disabled="true">-- Select City --</option>
                                            {cityData?.map((item) => (
                                                <option value={item.cityId}>{item.name}</option>
                                            ))}
                                        </Form.Select>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Check className='mb-3' name="" type="checkbox" label="Show in Menu" onChange={handleInputChange}/>
                                    </Col>
                                    <Col md={3} sm={2} className="mb-3">
                                        <Form.Check className='mb-3' name="" type="checkbox" label="Mail Subscription" onChange={handleInputChange}/>
                                    </Col>
                                    <Col md={12}>
                                        <Form.Label className="">Reference</Form.Label>
                                        <Form.Control type="text" className="form-control" placeholder="Reference"
                                            aria-label="Reference" name="reference" value={formData.reference}
                                            onChange={handleInputChange} />
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
    );
};

export default AddUser;
