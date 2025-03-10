let serverUrl

export function setServerUrl(url) {
    serverUrl = url
}

export async function getDataFrom(resource) {
    try {
      const response = await fetch(`${serverUrl}${resource}`);
      if (!response.ok) {
        throw new Error(`Response status: ${response.status}`);
      }
  
      const json = await response.json();
      return json
    } catch (error) {
      console.error(error.message);
    }
  }


  export async function patchDataFor(resource, data) {
    try {
      const response = await fetch(`${serverUrl}${resource}`,
        {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      });
      if (!response.ok) {
        throw new Error(`Response status: ${response.status}`);
      }
  
      const json = await response.json();
      return json
    } catch (error) {
      console.error(error.message);
    }
  }