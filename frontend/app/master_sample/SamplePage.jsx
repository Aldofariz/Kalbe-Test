import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import React from 'react'
import DataTable from './dataTable'

const SamplePage = () => {
  return (
    <section className='p-5 bg-gray-200 min-h-screen font-sans'>
        <div className='pt-4 text-3xl font-bold font-sans text-neutral-700'>Master Sample Type</div>
        <h2 className='text-gray-500'>Manage sample type data</h2>
        <div className='max-w-7xl mx-auto bg-white rounded-lg shadow-md p-6 mt-4'>
                {/* Table Data */}
                <div>
                    <DataTable/>
                </div>
            </div>
    </section>
  )
}

export default SamplePage