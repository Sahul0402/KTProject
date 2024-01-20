
export async function postDataService(apiUrl, data = null, contentType = "application/json") {
  try {
    var url = "https://localhost:44351/";
    apiUrl = url + apiUrl;
    const response = await fetch  (apiUrl, {
      method: "POST",
      headers: {
        "Content-Type": contentType,
      },
      body: data,
    });

    const responseData = {
      isSuccess: response.ok,
      data: await response.json(),
    };
    return responseData;
  } catch (error) {
    console.log(`Unable to reach api. ${error?.message}`);
  }
}

export async function getDataService(apiUrl, contentType = "application/json") {
  try {
    var url = "https://localhost:44351/";
    apiUrl = url + apiUrl;
    const response = await fetch(apiUrl, {
      method: "GET",
      headers: {
        "Content-Type": contentType,
      },
    });
    return await response.json();
  } catch (error) {
    console.log(`Unable to reach api. ${error?.message}`);
  }
}